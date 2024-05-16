using System.Text;
using Method;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<DBConfig>();
builder.Services.AddScoped<WeatherAction>();
builder.Services.AddScoped<WeatherforecastService>();
builder.Services.AddSingleton<Logger>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:SecretKey"]))
    };
    // option.Events = new JwtBearerEvents()
    // {
    //     OnMessageReceived = (ctx) =>
    //     {
    //         if (ctx.Request.Query.ContainsKey("token"))
    //         {
    //             ctx.Token = ctx.Request.Query["token"];
    //         }
    //         return Task.CompletedTask;
    //     }
    // };
});
builder.Services.AddCors(
    strategy => strategy.AddPolicy("AllowAll",
    policy => policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin())
);
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
// if (!app.Environment.IsDevelopment())
// {
//     app.UseHttpsRedirection();
// }

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
