using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScholarShip.Data;
using ScholarShip.Data.Repository;
using ScholarShip.Interfaces;
using ScholarShip.Models;
using ScholarShip.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetSection("ConnectionString").Get<string>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

/*builder.Services.AddDefaultIdentity<Profil, IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>();*/

builder.Services.AddDefaultIdentity<Profil>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();

builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IAnnonceSearchService,AnnonceSearchService>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAllOrigins",
		builder =>
		{
			builder.AllowAnyOrigin()
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
});

var app = builder.Build();



//Skriv nedenstående for at lave connection ! Tilføj standard connectionstring
//cd /.ScholarShip
//dotnet user-secrets init
//dotnet user-secrets set "ConnectionString" "Data Source=localhost;Initial Catalog=ScholarShip;User ID=SA;Password=Password;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAllOrigins");

using (var scope = app.Services.CreateScope())
{
	using var appdb = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	appdb.Database.Migrate();
}

app.Run();

