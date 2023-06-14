using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json.Converters;
using SME.Simulador.Prova.Serap.Api;
using SME.Simulador.Prova.Serap.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;    
});

builder.Services.AddHttpContextAccessor();
RegistrarDependencias.Registrar(builder);
ConfigurarDependencias.Configurar(builder.Services);

builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(setup =>
    {
        setup.SerializerSettings.Converters.Add(new StringEnumConverter());
        setup.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })    
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());    
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => config.ConfigurarDocumentacao());
builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

app.UseResponseCompression();

app.UseSwagger(c =>
{
    c.RouteTemplate = "simulador/swagger/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/simulador/swagger/v1/swagger.json", "SME.Simulador.Prova.SERAp.Api v1");
    c.RoutePrefix = "simulador/swagger";    
});

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
