#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["ProductAspApi/ProductAspApi.csproj", "ProductAspApi/"]
COPY ["ProductBusiness/ProductBusiness.csproj", "ProductBusiness/"]
COPY ["ProductData/ProductData.csproj", "ProductData/"]
COPY ["ProductEntity/ProductEntity.csproj", "ProductEntity/"]
RUN dotnet restore "ProductAspApi/ProductAspApi.csproj"
COPY . .
WORKDIR "/src/ProductAspApi"
RUN dotnet build "ProductAspApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductAspApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductAspApi.dll"]