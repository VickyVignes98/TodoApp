# TODO App - Fullstack (React + .NET 6 + EF Core)

This is a fullstack TODO application with a **React frontend** and a **.NET 6 Web API backend** using **Entity Framework Core** for data access.

---

## 🚀 Features
- Add, update, and delete TODO items
- Fully responsive frontend (Vite + React)
- Backend API built with ASP.NET Core 6
- Entity Framework Core for database operations
- SQL database integration

---

## 🛠️ Tech Stack
**Frontend**
- React (Vite)
- Axios (API calls)
- CSS for responsive design

**Backend**
- ASP.NET Core 6 Web API
- Entity Framework Core
- SQL Server

---

## 📂 Project Structure
\\\
TodoApp/
│── src/
│   ├── Todo.Api/         # Backend API project
│   ├── Todo.Application/ # Application logic
│   ├── Todo.Domain/      # Domain models
│   ├── Todo.Infrastructure/ # EF Core database layer
│── todo-client/          # React frontend
\\\

---

## ⚙️ Installation & Run

### 1️⃣ Backend (.NET API)
\\\powershell
cd src/Todo.Api
dotnet restore
dotnet run
\\\
Runs at:  
- https://localhost:7068  
- http://localhost:5070  

### 2️⃣ Frontend (React)
\\\powershell
cd todo-client
npm install
npm run dev
\\\
Runs at:  
- http://localhost:5173

---

## 📸 Screenshots
<img width="558" height="415" alt="image" src="https://github.com/user-attachments/assets/62878563-4414-40bf-b3a6-3cae6e396096" />


---

## 👤 Author
S. Vignes
