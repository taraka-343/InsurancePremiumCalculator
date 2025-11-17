using InsurancePremiumCalcBE.CustomMiddleware;
using InsurancePremiumCalcBE.Services;
using InsurancePremiumCalcBE.Services.IServices;

var builder = WebApplication.CreateBuilder(args);
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
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

// Map controller routes (VERY IMPORTANT)
app.MapControllers();

app.Run();
