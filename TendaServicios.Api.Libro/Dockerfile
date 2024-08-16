# Establecer la imagen base para el SDK de .NET
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar el archivo .csproj y restaurar las dependencias
COPY TendaServicios.Api.Libro/*.csproj ./TendaServicios.Api.Libro/
RUN dotnet restore TendaServicios.Api.Libro/TendaServicios.Api.Libro.csproj

# Copiar el resto de los archivos y construir la aplicación
COPY TendaServicios.Api.Libro/ ./TendaServicios.Api.Libro/
WORKDIR /app/TendaServicios.Api.Libro
RUN dotnet build -c Release -o /app/build

# Establecer la imagen base para el runtime de .NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar los archivos de la compilación desde el contenedor anterior
COPY --from=build-env /app/build .

# Exponer el puerto y ejecutar la aplicación
EXPOSE 80
ENTRYPOINT ["dotnet", "TendaServicios.Api.Libro.dll"]
