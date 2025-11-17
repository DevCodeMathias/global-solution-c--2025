# 📘 ExchangeHouse API

A **ExchangeHouse API** é um serviço desenvolvido em **.NET 8** com **EF Core**, que permite o gerenciamento de **usuários** e seus **benefícios corporativos**.

O sistema suporta diferentes tipos de benefícios:

- 🎁 Itens (kits, brindes, materiais corporativos)  
- 💤 Folgas (Day Off)  
- 💆 Serviços (wellness, plano de saúde, etc.)  
- 🧩 Outros benefícios customizáveis

Cada usuário possui:
- Dados pessoais  
- Endereço completo  
- Relacionamento **1:N** com benefícios  

---

# 🧱 Tecnologias Utilizadas

| Tecnologia | Uso |
|-----------|-----|
| **.NET 8 / ASP.NET Core** | Backend da API |
| **Entity Framework Core 8** | ORM e migrations |
| **PostgreSQL (Supabase)** | Banco de dados |
| **Swagger / OpenAPI** | Documentação da API |
| **Dependency Injection** | Inversão de controle |
| **Async/Await** | Programação assíncrona |
| **REST/JSON** | Padrão de comunicação |

---

# 🏛️ Arquitetura do Projeto

```bash
exchangeHouse_api/
├── Domain/
│ ├── Entitty/
│ │ ├── User.cs
│ │ └── Benefit.cs
│ └── Interfaces/
│ └── IBenefitService.cs
│
├── Application/
│ └── Service/
│ └── BenefitService.cs
│
├── Infrastructure/
│ └── Data/
│ └── AppDbContext.cs
│
├── Controllers/
│ └── BenefitsController.cs
│
├── Program.cs
├── appsettings.json
└── README.md
```
Principais práticas aplicadas:

- Clean Architecture  
- DDD básico  
- Controllers enxutos  
- Serviços contendo as regras de negócio  
- EF Core com Fluent API  
- Separação clara das camadas  

---

# 🗂️ Entidades

## 👤 User

Campos:

- Id  
- Name  
- Email  
- PasswordHash  
- Role  
- Endereço completo  
  - Street, Number, Complement  
  - Neighborhood, City, State  
  - ZipCode, Country  
- CreatedAt, UpdatedAt  
- Lista de benefícios (`ICollection<Benefit>`)

---

## 🎁 Benefit

Campos:

- Id  
- User_Id (FK para User)  
- Name  
- Description  
- Category (Item, DayOff, Service, Other)  
- Quantity  
- Amount  
- MetadataJson  
- CreatedAt, UpdatedAt  




