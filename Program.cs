using InsurancePremiumCalcBE.Services;
using InsurancePremiumCalcBE.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();

// Map controller routes (VERY IMPORTANT)
app.MapControllers();

app.Run();
