using ProyectoFinal.DAL;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔹 Dependency Injection
builder.Services.AddScoped<AppDbConnection>();
builder.Services.AddScoped<DuenoDAL>();
builder.Services.AddScoped<MascotaDAL>();
builder.Services.AddScoped<VacunaDAL>();

var app = builder.Build();

// 🔹 Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
