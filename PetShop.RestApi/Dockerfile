FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY PetShop.RestApi/PetShop.RestApi.csproj PetShop.RestApi/
COPY PetShop.Core.Entity/PetShop.Core.Entity.csproj PetShop.Core.Entity/
COPY PetShop.Core/PetShop.Core.csproj PetShop.Core/
COPY PetShop.Infrastructure.Data/PetShop.Infrastructure.Data.csproj PetShop.Infrastructure.Data/
RUN dotnet restore PetShop.RestApi/PetShop.RestApi.csproj
COPY . .
WORKDIR /src/PetShop.RestApi
RUN dotnet build PetShop.RestApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PetShop.RestApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PetShop.RestApi.dll"]
