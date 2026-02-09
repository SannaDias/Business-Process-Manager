📌 ProcessManager
=================

Sistema de gerenciamento de **Áreas**, **Processos** e **Subprocessos**, desenvolvido com **ASP.NET Core** no backend e **React + Vite** no frontend, aplicando princípios de **Clean Architecture**, **DDD** e o **Composite Pattern** para modelar hierarquias de processos.

📖 Visão Geral
--------------

O **ProcessManager** permite:

*   Criar **Áreas organizacionais**
    
*   Criar **Processos principais**
    
*   Criar **Subprocessos** de forma hierárquica (recursiva)
    
*   Editar processos existentes
    
*   Excluir processos (com remoção em cascata dos subprocessos)
    
*   Visualizar a árvore completa de processos por área
    

O projeto foi pensado para ser **escalável**, **testável** e **fácil de manter**, separando claramente responsabilidades entre as camadas.

🧱 Arquitetura do Projeto
-------------------------

O projeto segue uma **arquitetura em camadas**, inspirada na **Clean Architecture**:
  frontend/    └── process-manager-frontend (React)  src/  ├── ProcessManager.API  │   └── Controllers (REST)  │  ├── ProcessManager.Application  │   ├── UseCases  │   ├── DTOs  │   └── Interfaces  │  ├── ProcessManager.Domain  │   ├── Entities  │   └── Business Rules  │  ├── ProcessManager.Infrastructure  │   ├── EF Core  │   └── Repositories  │  └── Database (SQLite)   `

### 🔹 Frontend

*   React + Vite
    
*   Componentização clara
    
*   Comunicação com API via camada de serviços (api.js)
    
*   Estado controlado por hooks (useState, useEffect)
    
*   Renderização recursiva da árvore de processos
    

### 🔹 Backend

*   ASP.NET Core Web API
    
*   Controllers finos (apenas orquestração HTTP)
    
*   Casos de uso isolados por responsabilidade
    
*   Domínio independente de infraestrutura
    
*   SQLite para persistência
    

🧠 Conceitos Aplicados
----------------------

### ✔ Clean Architecture

*   O **Domínio não depende de nada**
    
*   A **Application Layer** orquestra regras de negócio
    
*   A **Infrastructure Layer** implementa persistência
    
*   A **API** apenas expõe endpoints HTTP
    

### ✔ Domain-Driven Design (DDD)

*   Entidades ricas (Area, Process)
    
*   Regras encapsuladas no domínio (ex: atualização de nome)
    
*   Repositórios como abstrações
    

### ✔ Composite Pattern

Processos podem conter subprocessos, que também são processos:

 Processo   ├── Subprocesso   │    └── Subprocesso   └── Subprocesso   `

Isso permite tratar **processos e subprocessos da mesma forma**.

🛠️ Tecnologias Utilizadas
--------------------------

### Backend

*   .NET 9
    
*   ASP.NET Core
    
*   Entity Framework Core
    
*   SQLite
    
*   C#
    

### Frontend

*   React
    
*   Vite
    
*   JavaScript (ES6+)
    
*   Fetch API
    
*   CSS (inline e modular)
    

🚀 Como Executar o Projeto
--------------------------

### 🔹 Backend

 cd src/ProcessManager.API  dotnet restore  dotnet run

A API será iniciada em:

*   https://localhost:64612
    
*   http://localhost:64613
    

### 🔹 Frontend
  cd frontend/process-manager-frontend  npm install  npm run dev 

A aplicação estará disponível em:

*   http://localhost:5173
    

🔌 Endpoints da API
-------------------

### 📍 Áreas

MétodoEndpointDescriçãoPOST/api/areasCria uma nova áreaGET/api/areasLista todas as áreasGET/api/areas/{areaId}/processesRetorna a árvore de processos

### 📍 Processos

MétodoEndpointDescriçãoPOST/api/processesCria processo ou subprocessoPUT/api/processes/{id}Atualiza nome do processoDELETE/api/processes/{id}Remove processo e subprocessos

🧪 Testes de API (Exemplos)
---------------------------

### Criar Área

 POST /api/areas  Content-Type: application/json  {    "name": "Financeiro"  }   

### Criar Processo

  POST /api/processes  Content-Type: application/json  {    "name": "Contas a pagar",    "areaId": "GUID_DA_AREA",    "parentProcessId": null  }   

### Criar Subprocesso

POST /api/processes  Content-Type: application/json  {    "name": "Validação de notas",    "areaId": "GUID_DA_AREA",    "parentProcessId": "GUID_DO_PROCESSO"  }  

### Atualizar Processo

 PUT /api/processes/{id}  Content-Type: application/json  {    "name": "Contas a pagar - Atualizado"  }   

### Deletar Processo

 DELETE /api/processes/{id}   

🎨 Interface do Usuário
-----------------------

*   Visualização hierárquica clara
    
*   Indentação automática por nível
    
*   Criação inline de subprocessos
    
*   Modal para edição
    
*   Confirmação antes de exclusão
    

O foco da UI é **clareza, usabilidade e manutenção simples**, sem misturar regras de negócio com apresentação.

📌 Possíveis Evoluções
----------------------

*   Autenticação e autorização
    
*   Paginação de áreas
    
*   Drag & drop de processos
    
*   Testes automatizados (unitários e integração)
    
*   Tema customizável (dark/light)
    
*   Persistência em banco relacional maior (PostgreSQL / SQL Server)
    

👤 Autor
--------

Desenvolvido por **Sanna Dias**Projeto criado com foco em **aprendizado profundo de arquitetura**, **boas práticas** e **preparação para entrevistas técnicas**.
