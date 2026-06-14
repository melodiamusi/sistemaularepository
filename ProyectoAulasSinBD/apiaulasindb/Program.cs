using apiaulasindb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. REGRA DE CONEXIÓN A BASE DE DATOS (Ya la tienes) ---
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// === 2. PEGA ESTA NUEVA LÍNEA AQUÍ (Configura el servicio de CORS) ===
builder.Services.AddCors();
// ======================================================================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// === 3. PEGA ESTAS LÍNEAS AQUÍ (Activa el CORS antes de los controladores) ===
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
// =============================================================================

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();