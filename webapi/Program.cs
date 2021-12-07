var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
  .AddJsonOptions(opt => {
    opt.JsonSerializerOptions.NumberHandling = JsonNumberHandling.WriteAsString;
    opt.JsonSerializerOptions.AddContext<webapi.Controllers.Mine.SourceGenerationContext>();
  });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//This
app.UseStaticFiles();

app.UseCors((b) => {
  b.AllowAnyOrigin();
  b.AllowAnyMethod();
});

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
