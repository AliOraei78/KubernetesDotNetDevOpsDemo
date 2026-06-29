# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy project files
COPY ["KubernetesDotNetDevOpsDemo/KubernetesDotNetDevOpsDemo.csproj", "./"]
RUN dotnet restore "KubernetesDotNetDevOpsDemo.csproj"

# Copy the rest of the code
COPY . .
WORKDIR "/src"
RUN dotnet publish "KubernetesDotNetDevOpsDemo/KubernetesDotNetDevOpsDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage (Runtime) - lightweight and optimized
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Default ASP.NET port
EXPOSE 8080
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "KubernetesDotNetDevOpsDemo.dll"]