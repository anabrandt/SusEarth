// Importa os namespaces necessários
using Microsoft.EntityFrameworkCore;
using SusEarth.API.Data;  // Importa o contexto do banco de dados
using SusEarth.API.Services;  // Importa os serviços da API
using SusEarth.Services;  // Importa os serviços gerais
using SusEarth.API.Services.CEP;  // Importa o serviço relacionado ao CEP

// Cria o builder para configurar a aplicação
var builder = WebApplication.CreateBuilder(args);

// Configura o contexto do banco de dados Oracle
builder.Services.AddDbContext<OracleDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"))  // Obtém a string de conexão do arquivo de configuração
           .LogTo(Console.WriteLine, LogLevel.Information));  // Habilita o log das consultas SQL no console

// Configura o CORS (Cross-Origin Resource Sharing) para permitir acessos de qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permite qualquer origem
              .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc)
              .AllowAnyHeader();  // Permite qualquer cabeçalho HTTP
    });
});

// Registra o serviço para trabalhar com CEP (Localização de endereço)
builder.Services.AddScoped<ICEPService, CEPService>();  // Adiciona o serviço de CEP com escopo limitado

// Registra o serviço MetroService como singleton, ou seja, uma única instância será criada durante o ciclo de vida da aplicação
builder.Services.AddSingleton<MetroService>();

// Adiciona os controllers para a aplicação (gerencia as rotas da API)
builder.Services.AddControllers();

// Configura o Swagger (ferramenta de documentação da API)
builder.Services.AddEndpointsApiExplorer();  // Adiciona suporte para explorar os endpoints da API
builder.Services.AddSwaggerGen();  // Gera a documentação do Swagger

// Cria a aplicação com base na configuração do builder
var app = builder.Build();

// Configura o middleware que só será ativado em ambientes de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Habilita o Swagger para a documentação da API
    app.UseSwaggerUI();  // Habilita a interface do usuário do Swagger para acessar a documentação
}

// Configura o middleware para permitir o CORS com a política definida anteriormente
app.UseCors("AllowAll");

// Configura o redirecionamento automático para HTTPS
app.UseHttpsRedirection();

// Habilita a autorização para proteger as rotas (necessário para autenticação)
app.UseAuthorization();

// Mapeia os controllers para as rotas definidas na aplicação
app.MapControllers();

// Executa a aplicação
app.Run();
