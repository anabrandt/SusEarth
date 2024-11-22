# 🌱 **SusEarth - Energia para um Futuro Sustentável**  

### 💬 **Integrantes**  
- **Ana Carolina Tavares** - RM552283  
- **Vinicius Minei** - RM98486  
- **Sofia Sprocatti** - RM99208  
- **Gabriel Lopes Pereira** - RM98023  

---

## 🌍 **Visão Geral do Projeto**  

O **SusEarth** é uma iniciativa tecnológica que combina inovação e sustentabilidade, com foco no descarte correto de resíduos eletrônicos. A API conecta usuários a Pontos de Entrega Voluntária (PEVs) localizados em estações de metrô, facilitando o acesso a soluções ambientais e promovendo práticas conscientes.  

Além disso, o projeto conta com uma **Inteligência Artificial (IA) preditiva** que, com base em dados históricos de descarte, analisa e prevê como o descarte correto pode mitigar problemas ambientais. Essa IA utiliza um modelo de aprendizado supervisionado para identificar padrões, ajudando a tomar decisões mais assertivas no planejamento e na alocação dos PEVs.  

---

## 🧠 **IA Preditiva no SusEarth**  

A IA preditiva foi desenvolvida para analisar grandes volumes de dados sobre descarte eletrônico e gerar insights que suportam ações estratégicas. Com um banco de dados robusto e diverso, alimentado por históricos de descarte e impactos ambientais, a IA pode:  

1. **Prever impactos ambientais reduzidos:**  
   Estimativa de emissões de CO₂ e resíduos tóxicos evitados pelo descarte adequado.  

2. **Identificar padrões de descarte:**  
   Reconhece os locais e períodos com maior demanda por PEVs.  

3. **Sugerir alocação estratégica de recursos:**  
   Auxilia na definição de novos pontos de coleta para otimizar o uso dos PEVs.  

4. **Propor campanhas de conscientização:**  
   Baseia-se nos dados para sugerir regiões prioritárias para campanhas educativas.  

---

# Arquitetura SusEarth  
<div style="display:flex;">  
  <img align="center" alt="Diagrama-UML" src="arquitetura.png">  
</div>  

---

## 🔧 **Endpoints Disponíveis**  

A API oferece funcionalidades integradas para facilitar a gestão de PEVs e suportar o funcionamento da IA.  

### **User Controller**  
Gerencia os usuários que interagem com o sistema.  

- **`GET /api/User/{id}`**  
  Obtém os detalhes de um usuário específico pelo ID.  
- **`POST /api/User`**  
  Adiciona um novo usuário ao sistema.  

---

### **WasteInfo Controller**  
Fornece informações sobre os PEVs em estações de metrô.  

- **`GET /api/WasteInfo/findNearestMetro/{cep}`**  
  Retorna a estação de metrô mais próxima de um endereço (identificado pelo CEP).  
- **`POST /api/WasteInfo`**  
  Adiciona informações de novos PEVs.  

---

A **Inteligência Artificial (IA)** no **SusEarth** é utilizada para otimizar o processo de descarte de resíduos eletrônicos. A IA analisa dados históricos de descarte, identificando padrões e previsões sobre quando e onde os resíduos serão descartados. Com isso, é possível alocar estrategicamente os **Pontos de Entrega Voluntária (PEVs)**, melhorar a logística de coleta e propor campanhas de conscientização em áreas com baixo engajamento. A IA também calcula o impacto ambiental evitado com o descarte correto, promovendo um sistema mais eficiente e sustentável.

---

## 🛠 **Como Testar o Sistema**  

### 1. Clone o repositório  
```bash  
git clone https://github.com/anabrandt/susearth.git  
```  

### 2. Instale as dependências  
```bash  
dotnet restore  
```  

### 3. Execute o servidor  
```bash  
dotnet run  
```  

A API estará disponível em `https://localhost:7201`.  

---

## 📝 **Documentação da API**  

Acesse a documentação interativa com o **Swagger** para explorar e testar os endpoints:  
[Swagger UI - SusEarth](https://localhost:7201/swagger/index.html)  

---  

## 📝 **Conclusão**  

O **SusEarth** não é apenas uma solução para descarte de resíduos eletrônicos, mas uma plataforma que une **tecnologia, sustentabilidade e inteligência artificial** para criar um impacto positivo no mundo. Este é apenas o começo de um futuro mais verde e inteligente!  