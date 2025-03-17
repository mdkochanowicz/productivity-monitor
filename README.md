# Productivity Monitor

🚀 **Productivity Monitor** is a work-in-progress microservices-based application designed to track and analyze productivity. It utilizes modern technologies such as .NET, Next.js, RabbitMQ, PostgreSQL, and MongoDB, all running in a Dockerized environment for easy development and deployment.

---

## 📦 Architecture Overview

The application follows a microservices architecture for better scalability, modularity, and maintainability. Each service is developed independently and communicates via messaging queues for seamless integration.

### Key Components:

- **.NET Backend Services (C#)** – Modular microservices handling business logic.
- **Next.js Frontend** – User-friendly web interface.
- **RabbitMQ** – Messaging broker for service communication.
- **PostgreSQL** – Structured data storage.
- **MongoDB** – Event and unstructured data storage.
- **Auth.js** – Authentication and session handling.
- **Docker** – Container orchestration for all services.

---

## 🏗️ Services (Planned & In Progress)

| Service              | Description                                 | Status         |
|---------------------|---------------------------------------------|----------------|
| Auth Service         | User authentication and identity management | 🔄 In Progress |
| User Service         | User profile and role management            | 🔄 In Progress |
| Activity Tracker     | Logs user activity data                     | 🔄 In Progress |
| Reporting Service    | Aggregates and presents productivity insights | ⏳ Planned     |
| Notification Service | Sends alerts and reminders                  | ⏳ Planned     |

---

## 🐳 Getting Started (Local Development)

> **Requirements:** Docker & Docker Compose

```bash
docker-compose up --build
```
Frontend: http://localhost:3000

Backend services run internally via Docker network

✅ Features (Planned)
- Secure user authentication
- Real-time activity tracking
- Analytics and reporting dashboards
- Role-based access control
- Email/notification system
- Clean and modern UI

⚙️ Tech Stack
- Frontend: Next.js, Tailwind CSS
- Backend: .NET 8.0, C#
- Databases: PostgreSQL, MongoDB
- Messaging: RabbitMQ
- Auth: Auth.js
- Containerization: Docker, Docker Compose

📍 Roadmap
 - Docker infrastructure setup
 - Authentication microservice
 - User and activity services
 - Frontend dashboard development
 - Reporting and analytics features
 - CI/CD integration

 🤝 Contributing
This project is under active development. Contributions and ideas are very welcome!
Feel free to fork, open issues, or submit pull requests.


