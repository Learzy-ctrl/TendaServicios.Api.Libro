# Usar la imagen oficial de .NET 7 SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar los archivos csproj y restaurar las dependencias
COPY TendaServicios.Api.Libro/*.csproj ./TendaServicios.Api.Libro/
RUN dotnet restore TendaServicios.Api.Libro/TendaServicios.Api.Libro.csproj

# Copiar el resto de los archivos y compilar la aplicación
COPY TendaServicios.Api.Libro/ ./TendaServicios.Api.Libro/
WORKDIR /app/TendaServicios.Api.Libro
RUN dotnet build -c Release -o /app/build

# Establecer la imagen base para el runtime de .NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar los archivos de la compilación desde el contenedor anterior
COPY --from=build-env /app/out .

# Exponer el puerto en el que la aplicación escuchará
EXPOSE 80

# Definir el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "TendaServicios.Api.Libro.dll"]
