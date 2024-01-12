using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using PetAdoption.API.Data;
using PetAdoption.API.Services;
using PetAdoption.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwtOptions => jwtOptions.TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration));

builder.Services.AddDbContext<PetContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Pet")), 
    ServiceLifetime.Transient
);

builder.Services.AddTransient<IAuthService, AuthService>()
                .AddTransient<TokenService>()
                .AddTransient<IPetService, PetService>()
                .AddTransient<IUserPetService, UserPetService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    ApplyDbMigrations(app.Services);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run("https://localhost:7055");

static void ApplyDbMigrations(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<PetContext>();
    if (context.Database.GetPendingMigrations().Any()) context.Database.Migrate();
}


