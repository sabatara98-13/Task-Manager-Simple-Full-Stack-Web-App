# Task Manager

A simple full-stack task app with a C# ASP.NET Core API, SQLite database, and an HTML/CSS/JS frontend.

## How to Run

### 1. Start Backend API
```bash
cd saba_final_task_backend/saba_final_task_backend
dotnet run
```
- API Endpoint: `http://localhost:5000/api/tasks`
- Visual API Dashboard (Scalar / Swagger): `http://localhost:5000/scalar/v1` (or `http://localhost:5000/swagger`)
- VS Code Testing: `requests.http`

### 2. Open Frontend
- **Option 1 (VS Code):** Right-click `saba_final_task_frontend/index.html` and choose **Open with Live Server**.
- **Option 2 (Terminal):**
  ```bash
  cd saba_final_task_frontend
  python -m http.server 8000

  or

  python -m http.server 8000 --bind 127.0.0.1

  ```
  Then open `http://localhost:8000` in your browser.

## API Endpoints
- `GET /api/tasks` — List all tasks
- `GET /api/tasks/{id}` — Get single task
- `POST /api/tasks` — Add new task
- `PUT /api/tasks/{id}` — Update task (mark done)
- `DELETE /api/tasks/{id}` — Delete task
