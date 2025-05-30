# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiamos todos los archivos del proyecto
COPY . ./

# Publicamos la app en modo Release
RUN dotnet publish -c Release -o /app/publish

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

# Copiamos la app ya publicada desde la etapa anterior
COPY --from=build /app/publish .

# Puerto en el que corre tu app
EXPOSE 80

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "Portafolio.dll"]
