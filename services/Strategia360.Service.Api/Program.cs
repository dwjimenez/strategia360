using DFast.Common.Authentication;
using DFast.Common.DataBaseSQL;
using DFast.Common.Http.Src;
using DFast.Common.Mvc;
using DFast.Common.RestEase;
using DFast.Seguridad.Api.Data;
using DFast.Seguridad.Api.Persistences;
using DFast.Seguridad.Api.Repositories;
using DFast.Seguridad.Api.Services;
using DFast.Seguridad.Api.Proxy;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin() // Cambia el origen a la URL de tu frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();

// para las metricas 12/06/2024
//builder.Services.AddTransient<IMetricsRegistry, MetricsRegistry>();

//**MANEJO DE BDD
builder.Services.AddDbContext<ContextDatabase>(
    opt =>
    {
        opt.UseSqlServer(builder.Configuration["bdd:cn"]);
    });

// Servicios base
builder.Services.AddScoped<ISqlAccess, SqlAccess>();
builder.Services.AddSPSql();

// Servicios espec�ficos
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IRegistroService, RegistroService>();

// Repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserSistemaRepository, UserSistemaRepository>();
builder.Services.AddScoped<IOtpRepository, OtpRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<ILogSeguridadRepository, LogSeguridadRepository>();
builder.Services.AddScoped<IRegistroRepository, RegistroRepository>();
//**FIN MANEJO DE BDD


builder.Services.AddScoped<INotificacionService, NotificacionService>();


//PARA EL MANEJO DEL MONITOR DE LOGS 06/12/2024
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .WriteTo.Console()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
//FIN PARA EL MANEJO DEL MONITOR DE LOGS

//PARA EL MANEJO DEL TRACING 06/12/2024
//builder.Services.AddJZipkin();
//FIN PARA EL MANEJO DEL TRACING

//PARA EL MANEJO DE METRICS 06/12/2024
//builder.WebHost.UseAppMetrics();
//FIN PARA EL MANEJO DE METRICS


// PROXY PARA SALIR A OTRO SERVICIO
builder.Services.RegisterServiceForwarder<ISendNotificationService>("dfast-notification");
builder.Services.RegisterServiceForwarder<IConfiguracionService>("dfast-configuracion");

////**REDIS PARA MANEJO DE CACHE 
//builder.Services.AddRedis();
//builder.Services.AddSingleton<IExtensionCache, ExtensionCache>();
////** FIN MANEJO DE CACHE 
///

// Inyecciones necesarias para dependencias
builder.Services.AddHttpContextAccessor(); // para IHttpContextAccessor
builder.Services.AddDistributedMemoryCache(); // para IDistributedCache
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions")); // JWT settings

// Token middleware
builder.Services.AddTransient<IAccessTokenService, AccessTokenService>();
builder.Services.AddTransient<AccessTokenValidatorMiddleware>();

// PROXY PARA SALIR A OTRO SERVICIO


//AUTOMAPPER FIJO
builder.Services.AddAutoMapper(cfg => cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies()));
//AUTOMAPPER

// PROXY FIJA SI SE MANEJA IR A OTRO SERVICIO
builder.Services.AddJwt();
builder.Services.AddProxyHttp();

// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// FIN WAGGER

var app = builder.Build();
// Habilitar CORS
app.UseCors("CorsPolicy");

app.UseMiddleware<GatewaySessionHandlerMiddleware>(); // si lo usas

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Sesion Centralizada
app.UseMiddleware<GatewaySessionHandlerMiddleware>();

// MANEJO DE EXCEPCIONES
app.UseErrorHandler();
//FIN MANEJO DE EXCEPCIONES
//MANEJO DE LA RESPUESTA
app.UseBaseResponseMiddleware();
//FIN MANEJO DE LA RESPUESTA


// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

DbCreated.CreateDbIfNotExists(app);

app.Run();