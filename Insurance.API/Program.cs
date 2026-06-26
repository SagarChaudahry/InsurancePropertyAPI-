using System.Text;
using Insurance.API.Middleware;
using Insurance.Application.Interface;
using Insurance.Application.Interface.IRepo;
using Insurance.Application.Interface.IService;
using Insurance.Application.Service;
using Insurance.Domain;
using Insurance.Infrastructure;
using Insurance.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
.Where(e => e.Value?.Errors.Count > 0)
.SelectMany(e => e.Value!.Errors)
.Select(e => e.ErrorMessage)
.ToList();
        var traceId = context.HttpContext.TraceIdentifier;

        var response = new ApiResponse<object>
        {
            responseCode = "97",
            message = string.Join(" | ", errors),
            result = null,
            meta = new { traceId }
        };
        return new BadRequestObjectResult(response);
    };
});



builder.Services.AddDbContext<ApplicationDBFactory>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
         .AddJwtBearer(options =>
         {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidIssuer = builder.Configuration["Jwt:Issuer"],
                 ValidAudience = builder.Configuration["Jwt:Audience"],

                 // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                 ClockSkew = TimeSpan.Zero,
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:APIKey").Value!)),
                 TokenDecryptionKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:EncryptedKey").Value!)),
                 ValidateIssuer = true,
                 ValidateAudience = true
             };

             options.Events = new JwtBearerEvents
             {
                 OnMessageReceived = context =>
                 {
                     var token = context.Request.Cookies["AccessTokenInsurance"];
                     if (string.IsNullOrEmpty(token))
                     {
                         var authHeader = context.Request.Headers["Authorization"]
                             .FirstOrDefault();
                         if (!string.IsNullOrEmpty(authHeader) &&
                             authHeader.StartsWith("Bearer "))
                         {
                             token = authHeader.Substring("Bearer ".Length).Trim();
                         }
                     }
                     if (!string.IsNullOrEmpty(token))
                     {
                         context.Token = token;
                     }

                     return Task.CompletedTask;
                 }
             };

         });

builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ITokenServices, TokenServices>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IConstructionTypeRepository, ConstructionTypeRepository>();
builder.Services.AddScoped<IConstructionTypeServices, ConstructionTypeServices>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


