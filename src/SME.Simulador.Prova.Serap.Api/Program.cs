using System.Reflection;
using Microsoft.AspNetCore.ResponseCompression;
using SME.Simulador.Prova.Serap.Api;
using SME.Simulador.Prova.Serap.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddHttpContextAccessor();
RegistrarDependencias.Registrar(builder);

builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());    
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => config.ConfigurarDocumentacao());

var app = builder.Build();

app.UseResponseCompression();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SME.Simulador.Prova.SERAp.Api v1"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

UtilizarDependencias.Utilizar(app);

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
