using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ModelsApi.Data;
using ModelsApi.Hubs;
using ModelsApi.Interfaces;
using ModelsApi.Models.Services;
using ModelsApi.Utilities;
using ScholarShip.Data.Repository;

namespace ModelsApi;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		var connectionString = builder.Configuration.GetSection("ConnectionString").Get<string>();

// Add services to the container.
		builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
		var MyAllowSpecificOrigins = "_myAllowAllOrigins";
		builder.Services.AddCors(options =>
		{
			options.AddPolicy(name: MyAllowSpecificOrigins,
				builder =>
				{
					builder.WithOrigins("http://localhost:3000")
						.AllowAnyHeader()
						.AllowAnyMethod()
						.AllowCredentials();
				});
		});
/*builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000");

    });
});*/

		builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(connectionString));
		builder.Services.AddControllers();
		builder.Services.AddSignalR();
// configure strongly typed settings objects
		var appSettingsSection = builder.Configuration.GetSection("AppSettings");
		builder.Services.Configure<AppSettings>(appSettingsSection);
		var appSettings = appSettingsSection.Get<AppSettings>();

// configure jwt authentication
		var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
		builder.Services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{
				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "FED Assignment 2 Model Manegement API",
				Version = "v2",
				Description = "API to manage models."
			});
			// Set the comments path for the Swagger JSON and UI.
			var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
			c.IncludeXmlComments(xmlPath);
			// Bearer token authentication
			OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme()
			{
				Name = "Bearer",
				BearerFormat = "JWT",
				Scheme = "bearer",
				Description = "Specify the authorization token.",
				In = ParameterLocation.Header,
				Type = SecuritySchemeType.Http,
			};
			c.AddSecurityDefinition("jwt_auth", securityDefinition);

			// Make sure swagger UI requires a Bearer token specified
			OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
			{
				Reference = new OpenApiReference()
				{
					Id = "jwt_auth",
					Type = ReferenceType.SecurityScheme
				}
			};
			OpenApiSecurityRequirement securityRequirements = new OpenApiSecurityRequirement()
			{
				{securityScheme, Array.Empty<string>()},
			};
			c.AddSecurityRequirement(securityRequirements);
		});

		builder.Services.AddTransient<IRepository, Repository>();
		builder.Services.AddTransient<IAnnonceSearchService, AnnonceSearchService>();
//Skriv nedenst?ende for at lave connection ! Tilf?j standard connectionstring
//cd /.ScholarShip
//dotnet user-secrets init
//dotnet user-secrets set "ConnectionString" "Data Source=localhost;Initial Catalog=ScholarShip;User ID=SA;Password=MyPassword123#;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
// Configure the HTTP request pipeline.


		var app = builder.Build();

// Configure the HTTP request pipeline.
		app.UseHttpsRedirection();
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			//c.SwaggerEndpoint("/swagger/v1/swagger.json", "Models API V2");
			//c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root 
		});

// Configure cors
/*
app.UseCors(x => x
    //.AllowAnyOrigin() // Not allowed together with AllowCredential
    //.WithOrigins("http://localhost:3000", "http://localhost:8080" "http://localhost:5000" )
    .SetIsOriginAllowed(x => _ = true)
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    );*/



		app.UseCors("_myAllowAllOrigins");



		app.UseAuthentication();
		app.UseAuthorization();

		app.MapHub<ChatHub>("/ChatHub");

		app.MapControllers();


//app.UseCors("AllowAllOrigins");

		using (var scope = app.Services.CreateScope())
		{
			var serviceProvider = scope.ServiceProvider;
			var dbContext = serviceProvider.GetService<ApplicationDbContext>();
			if (dbContext != null)
				DbUtilities.SeedData(dbContext, appSettings.BcryptWorkfactor);
			else throw new Exception("Unable to get dbContext!");
			using var appdb = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			appdb.Database.Migrate();
		}


		app.Run();
	}
}