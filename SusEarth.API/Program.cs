// Importa os namespaces necess�rios
using Microsoft.EntityFrameworkCore;
using SusEarth.API.Data;  // Importa o contexto do banco de dados
using SusEarth.API.Services;  // Importa os servi�os da API
using SusEarth.Services;  // Importa os servi�os gerais
using SusEarth.API.Services.CEP;  // Importa o servi�o relacionado ao CEP

// Cria o builder para configurar a aplica��o
var builder = WebApplication.CreateBuilder(args);

// Configura o contexto do banco de dados Oracle
builder.Services.AddDbContext<OracleDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))  // Obt�m a string de conex�o do arquivo de configura��o
           .LogTo(Console.WriteLine, LogLevel.Information));  // Habilita o log das consultas SQL no console

// Configura o CORS (Cross-Origin Resource Sharing) para permitir acessos de qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permite qualquer origem
              .AllowAnyMethod()  // Permite qualquer m�todo HTTP (GET, POST, etc)
              .AllowAnyHeader();  // Permite qualquer cabe�alho HTTP
    });
});

// Registra o servi�o para trabalhar com CEP (Localiza��o de endere�o)
builder.Services.AddScoped<ICEPService, CEPService>();  // Adiciona o servi�o de CEP com escopo limitado

// Registra o servi�o MetroService como singleton, ou seja, uma �nica inst�ncia ser� criada durante o ciclo de vida da aplica��o
builder.Services.AddSingleton<MetroService>();

// Adiciona os controllers para a aplica��o (gerencia as rotas da API)
builder.Services.AddControllers();

// Configura o Swagger (ferramenta de documenta��o da API)
builder.Services.AddEndpointsApiExplorer();  // Adiciona suporte para explorar os endpoints da API
builder.Services.AddSwaggerGen();  // Gera a documenta��o do Swagger

// Cria a aplica��o com base na configura��o do builder
var app = builder.Build();

// Configura o middleware que s� ser� ativado em ambientes de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Habilita o Swagger para a documenta��o da API
    app.UseSwaggerUI();  // Habilita a interface do usu�rio do Swagger para acessar a documenta��o
}

// Configura o middleware para permitir o CORS com a pol�tica definida anteriormente
app.UseCors("AllowAll");

// Configura o redirecionamento autom�tico para HTTPS
app.UseHttpsRedirection();

// Habilita a autoriza��o para proteger as rotas (necess�rio para autentica��o)
app.UseAuthorization();

// Mapeia os controllers para as rotas definidas na aplica��o
app.MapControllers();

// Executa a aplica��o
app.Run();
