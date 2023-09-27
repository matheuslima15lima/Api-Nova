using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem est� solicitando
        ValidateIssuer = true,

        // Valida quem est� recebendo
        ValidateAudience = true,

        //Define se o tempo de expira��o do token ser� validado
        ValidateLifetime = true,

        //Forma de criptografia e ainda valida��o da chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Health-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expira��o do Token
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde est� vindo (Issuer)
        ValidIssuer = "Webapi.HealthClinic.tarde",

        ValidAudience = "Webapi.HealthClinic.tarde"
    };
});







builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//Adiciona o gerador do Swagger
builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "Api de Eventos ",
    Description = "API para gerenciamento de Eventos ",

    Contact = new OpenApiContact
    {
        Name = "Matheus",
        Url = new Uri("https://github.com/matheuslima15lima")
    }

});

   // Configure o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

//Usando a autentica��o no swagger
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
{
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Value: Bearer TokenJWT"
});

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                }

            },
            new String[] {}
        }
    });

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//Para atender � interface do usu�rio do Swagger na raiz do aplicativo 
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
