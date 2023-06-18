FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiMovies/ApiMovies.csproj", "ApiMovies/"]
RUN dotnet restore "ApiMovies/ApiMovies.csproj"
COPY . .
WORKDIR "/src/ApiMovies"
RUN dotnet build "ApiMovies.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiMovies.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiMovies.dll"]

# MySQL configuration
ENV MYSQL_HOST=mysql
ENV MYSQL_PORT=3306
ENV MYSQL_USER=root
ENV MYSQL_PASSWORD=your_password
ENV MYSQL_DATABASE=your_database

# Download and run the MySQL container
FROM mysql:latest AS mysql
ENV MYSQL_ROOT_PASSWORD=your_password
ENV MYSQL_DATABASE=your_database
ENV MYSQL_USER=root
ENV MYSQL_PASSWORD=your_password

# Configure MySQL startup
COPY setup.sql /docker-entrypoint-initdb.d/