using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScholarShip.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetSection("ConnectionString").Get<string>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllers();
var app = builder.Build();

//Skriv nedenstående for at lave connection ! Tilføj standard connectionstring
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	using var appdb = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	appdb.Database.Migrate();
}

app.Run();