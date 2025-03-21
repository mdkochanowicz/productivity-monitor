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

 
# Workflow: Conventional Commits + Commitizen + standard-version

## 📦 Installation (one-time setup):
```bash
npm install --save-dev commitizen standard-version
npx commitizen init cz-conventional-changelog --save-dev --save-exact
```

This will automatically update `package.json` with:
```json
"scripts": {
  "commit": "cz",
  "release": "standard-version"
},
"config": {
  "commitizen": {
    "path": "./node_modules/cz-conventional-changelog"
  }
}
```

## 📌 How to commit following the convention?

### Instead of `git commit -m "..."`:
```bash
npm run commit
```

An interactive prompt will appear — you select the type of change, provide a description, etc.

### Example commit messages:
```
feat(api): add endpoint for user productivity stats
fix(auth): correct token validation logic
chore(deps): update package versions
docs(readme): add setup instructions
```

## 🚀 Creating Releases (automatic versioning)

### First release (only once):
```bash
npm run release -- --first-release
```

This will create:
- `CHANGELOG.md`,
- `v1.0.0` tag,
- bump the version in `package.json`.

### Subsequent releases:
```bash
npm run release
```

The version bump depends on the commit types:
- `feat:` → **minor**
- `fix:` → **patch**
- `BREAKING CHANGE:` → **major**

## ⬆ Pushing changes to GitHub:
```bash
git add .
git commit -m "chore(release): x.x.x"   ← if `standard-version` didn't do this automatically
git push
git push --tags
```

## 🧠 Additional commands:
```bash
git status       → check what's changed
git log          → commit history
npm run commit   → commit following the convention
npm run release  → create new version + changelog + tag
```

 🤝 Contributing
This project is under active development. Contributions and ideas are very welcome!
Feel free to fork, open issues, or submit pull requests.


