using InsurancePremiumCalcBE.CustomMiddleware;
using InsurancePremiumCalcBE.Services;
using InsurancePremiumCalcBE.Services.IServices;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowPremierClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
// Rate Limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("FixedWindowPolicy", limiterOptions =>
    {
        limiterOptions.PermitLimit = 5; // allow 5 requests
        limiterOptions.Window = TimeSpan.FromSeconds(10); // in 10 seconds
        limiterOptions.QueueLimit = 2; // queue extra 2 requests
        limiterOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

// Add services
builder.Services.AddScoped<IPremiumService, PremiumService>();

// Add controller support
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//adding custom middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseCors("AllowPremierClient");
app.UseRateLimiter();

// Map controller routes (VERY IMPORTANT)
app.MapControllers();

app.Run();
