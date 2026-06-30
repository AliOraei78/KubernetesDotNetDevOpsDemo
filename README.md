### Day 1: Base .NET Web API Setup

* An ASP.NET Core Web API project was created (.NET 8).
* A simple Tasks controller was added (basic CRUD).
* Initial Git repository was created on GitHub.

### Day 2: Project Dockerization

* A multi-stage Dockerfile was created for .NET 8.
* The image was built and tested locally using `docker run`.
* The API is accessible inside the container with Swagger enabled.

### Day 3: Kubernetes Basics I**

* Installed and configured **Minikube** and **kubectl**.
* Learned the fundamental Kubernetes concepts, including **Architecture**, **Pods**, and **Deployments**.
* Created and deployed the first Deployment with **2 replicas** of the API.

### Day 4: Kubernetes Basics 2**

* Defined the **Deployment** and **Service** using separate YAML files.
* Successfully deployed the API using `kubectl apply`.
* Enabled external access through a **NodePort** service.
