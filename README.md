---

### 💬 **Integrantes**


- **Ana Carolina Tavares** - RM552283
- **Vinicius Minei** - RM98486
- **Sofia Sprocatti** - RM99208
- **Gabriel Lopes Pereira** - RM98023

---

```markdown
# 🌱 **SusEarth - Energia para um Futuro Sustentável** 

---

## 🌍 **Visão Geral do Projeto**

O **SusEarth** é uma solução inovadora para o gerenciamento do descarte de resíduos eletrônicos. Através do uso de tecnologias como IoT, inteligência artificial generativa e uma plataforma inteligente, buscamos promover a sustentabilidade e facilitar a conscientização sobre o impacto do descarte inadequado desses resíduos.

Com a ajuda de dispositivos IoT, o projeto permite monitorar e rastrear os resíduos, incentivando o descarte correto e otimizando o processo de coleta com base nas necessidades locais.

---

## 💡 **Objetivo do Projeto**

Desenvolver uma plataforma inteligente que:
- Facilite o **descarte correto de resíduos eletrônicos**.
- Promova a **conscientização ambiental** e práticas sustentáveis.
- Forneça **análises preditivas** utilizando **IA generativa**.
- Utilize **design patterns** para garantir a manutenibilidade e eficiência do código.

### 🌿 **Tecnologias Utilizadas:**
- **Inteligência Artificial Generativa** para sugestões e melhorias contínuas.
- **.NET Core** para o desenvolvimento da API e lógica de negócios.
- **Swagger** para documentação da API.
- **MongoDB/Oracle** para armazenamento e gestão de dados.
- **XUnit e Moq** para garantir que a solução seja robusta por meio de testes automatizados.

---

## 🏙 **Apoio à Sustentabilidade:**

O **SusEarth** está alinhado com as iniciativas de sustentabilidade da cidade de São Paulo, que já realiza a coleta de **lixos eletrônicos** em pontos específicos da cidade, como parte de um esforço para promover o descarte correto de resíduos e incentivar práticas que contribuam para a preservação ambiental. 🌎✨

---

## 🔧 **Estrutura do Projeto**

O projeto segue uma arquitetura modular e escalável, com foco em **Clean Code** e **boas práticas de desenvolvimento**. A estrutura do código inclui:

- **API** em **.NET Core** para gerenciamento dos dados.
- **Banco de Dados** (Oracle/MongoDB) para armazenamento de informações.
- **IoT** para rastreamento de resíduos em tempo real.
- **Testes automatizados** para garantir a confiabilidade da aplicação.

---

## 🛠 **Como Testar a API**

Para testar a API do **SusEarth**, siga os seguintes passos:

### 1. **Clone o repositório:**

```bash
git clone https://github.com/anabrandt/susearth.git
```

### 2. **Instale as dependências:**

Abra o terminal e navegue até o diretório do projeto. Execute o comando abaixo para restaurar as dependências do projeto:

```bash
dotnet restore
```

### 3. **Configure o banco de dados:**

A API está configurada para utilizar o banco de dados **Oracle**. Certifique-se de configurar as credenciais no arquivo **appsettings.json** com as informações corretas de acesso.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "User Id=xxxxx;Password=xxxxxx;Data Source=xxxxxx/xxxx"
  }
}
```

### 4. **Execute o Projeto:**

Para rodar o projeto em sua máquina local, use o comando:

```bash
dotnet run
```

A API estará disponível em `https://localhost:7187`.

---

## 📝 **Documentação das APIs**

A documentação da API foi gerada automaticamente utilizando **Swagger**. Para acessar a documentação, basta acessar a URL:

```
https://localhost:7187/swagger
```

Na interface do Swagger, você pode visualizar todos os endpoints disponíveis e realizar testes diretamente pela interface.

---

## 🔍 **Testando os Endpoints no Postman**

Você pode usar o **Postman** para testar os endpoints da API. Siga as etapas abaixo:

1. Importe o arquivo Swagger ou adicione a URL da documentação (exemplo: `https://localhost:7187/swagger/v1/swagger.json`).
2. Selecione um endpoint da lista.
3. Clique em **Send** para testar a API.
4. Visualize a resposta da API e verifique os resultados.

---

## 📦 **Testes Automatizados**

Os testes unitários foram implementados utilizando **xUnit** e **Moq** para garantir a qualidade e o bom funcionamento da aplicação.

### Executar os testes:

```bash
dotnet test
```

---

## 🧹 **Práticas de Clean Code**

O código segue as melhores práticas de **Clean Code**, visando tornar o desenvolvimento mais claro e sustentável. Isso inclui:
- **Nomes claros e concisos** para métodos e variáveis.
- **Evitar duplicação de código** (DRY - Don't Repeat Yourself).
- **Testabilidade**: o código foi projetado para ser testável desde o início.
- **Documentação**: o código contém comentários explicativos e a documentação da API foi gerada automaticamente utilizando Swagger.

---

## 🎯 **Design Patterns Utilizados**

No desenvolvimento do **SusEarth**, utilizamos o padrão **Repository** para separar a lógica de acesso aos dados da lógica de negócios e facilitar a manutenção. O uso de design patterns garante que a aplicação seja escalável e fácil de estender.

---

## 📝 **Conclusão**

O **SusEarth** é um projeto inovador e importante para a promoção de práticas sustentáveis e o descarte responsável de resíduos eletrônicos. Estamos comprometidos com a qualidade do código, boas práticas de desenvolvimento e sustentabilidade.


**Agradecemos o seu interesse pelo projeto!Let's Rock The Future 🌱🌍**
```
