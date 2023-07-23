# Get Base Image (Full .NET Core SDK)
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy each csproj and restore as distinct layers
COPY ./Cimeri/Cimeri.Web/Cimeri.Web.csproj ./Cimeri.Web/
COPY ./Cimeri/Cimeri.Domain/Cimeri.Domain.csproj ./Cimeri.Domain/
COPY ./Cimeri/Cimeri.Repository/Cimeri.Repository.csproj ./Cimeri.Repository/
COPY ./Cimeri/Cimeri.Service/Cimeri.Service.csproj ./Cimeri.Service/
RUN dotnet restore ./Cimeri.Web/Cimeri.Web.csproj
RUN dotnet restore ./Cimeri.Domain/Cimeri.Domain.csproj
RUN dotnet restore ./Cimeri.Repository/Cimeri.Repository.csproj
RUN dotnet restore ./Cimeri.Service/Cimeri.Service.csproj

# Copy everything else and build
COPY ./Cimeri/Cimeri.Web/ ./Cimeri.Web/
COPY ./Cimeri/Cimeri.Domain/ ./Cimeri.Domain/
COPY ./Cimeri/Cimeri.Repository/ ./Cimeri.Repository/
COPY ./Cimeri/Cimeri.Service/ ./Cimeri.Service/
RUN dotnet publish ./Cimeri.Web/Cimeri.Web.csproj -c Release -o out

# Build the image for running migrations
FROM build-env AS migrator
WORKDIR /app/Cimeri.Web
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copy everything needed for migrations
COPY ./Cimeri/Cimeri.Domain/ ./Cimeri.Domain/
COPY ./Cimeri/Cimeri.Repository/ ./Cimeri.Repository/
COPY ./Cimeri/Cimeri.Service/ ./Cimeri.Service/
COPY ./Cimeri/Cimeri.Web/Cimeri.Web.csproj ./Cimeri.Web/
COPY wait-for-it.sh .

# Apply migrations
ENTRYPOINT ["./wait-for-it.sh", "db:1433", "--", "dotnet", "ef", "database", "update"]

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Cimeri.Web.dll"]
