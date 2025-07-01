# 🎓 Student Task Manager – Blazor Server App with Web API & SQL Server

This project is a **Blazor Server Web Application** developed for managing students, courses, and their academic tasks. It uses a **3-Tier Architecture (DAL → BLL → UI)** and integrates **ASP.NET Core Web API**, **ADO.NET**, and **MS SQL Server** for robust and modular development.

---

## 📌 Features

- ✅ **Blazor Server UI** (not WebAssembly)
- ✅ **Courses, Tasks, and Users** modules
- ✅ **Full CRUD operations**
  - Courses: via RESTful Web API
  - Tasks & Users: via ADO.NET (3-Tier)
- ✅ **Google Authentication** (optional)
- ✅ **Form Validation**
- ✅ **SQL Server Database**
- ✅ **3-Tier Architecture**:
  - DAL (Data Access Layer using ADO.NET)
  - BLL (Business Logic Layer)
  - Presentation (Blazor Components)
- ✅ **Dependency Injection**
- ✅ **API Consumption using HttpClient**
- ✅ **Bootstrap Responsive UI**

---

## 🛠️ Technologies Used

- **Blazor Server** (.NET 8)
- **ASP.NET Core Web API**
- **ADO.NET (SqlConnection, SqlCommand, SqlDataReader)**
- **Microsoft SQL Server**
- **Entity Models (POCO classes)**
- **Bootstrap 5**
- **C# + Razor Components**
- **Git & GitHub for version control**

---

## 🗂️ Database Schema (3 Tables)

1. **Users**
2. **Courses**
3. **Tasks**
- Each task is linked to a course and a user via **foreign keys**
- Tables follow **normalization and constraints** (PKs & FKs)

---

## 🚀 How to Run

1. **Clone this repo:**
   ```bash
   git clone https://github.com/yourusername/StudentTaskManager.git
