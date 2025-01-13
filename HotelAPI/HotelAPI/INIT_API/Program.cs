
var builder = WebApplication.CreateBuilder(args);

// Ajouter les services nécessaires
builder.Services.AddControllers();
builder.Services.AddScoped<Chambre_GET_Service>(); // Enregistrement du service
builder.Services.AddScoped<Chambre_GET_Query>();  // Si utilisé dans le service
builder.Services.AddDbContext<AppDbContext>();

// Swagger pour la documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure l'application (middleware, etc.)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();