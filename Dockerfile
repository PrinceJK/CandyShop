#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /src
COPY *.sln .
COPY CandyShop/*.csproj CandyShop/
COPY CandyShop.Core/*.csproj CandyShop.Core/
COPY CandyShop.Data/*.csproj CandyShop.Data/
COPY CandyShop.Models/*.csproj CandyShop.Models/
RUN dotnet restore CandyShop/*.csproj
RUN dotnet restore CandyShop.Core/*.csproj
RUN dotnet restore CandyShop.Data/*.csproj
RUN dotnet restore CandyShop.Models/*.csproj

COPY . .

# #Testing
# FROM base AS testing
# WORKDIR /src/CandyShop
# RUN dotnet build
# #WORKDIR /src/CandyShop.Testnew
# WORKDIR /src/CandyShop.Testnew
# RUN dotnet test



#Publishing
FROM base AS publish
WORKDIR /src/CandyShop
RUN dotnet publish -c Release -o /src/publish

#Get the runtime into a folder called app
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
COPY --from=publish /src/CandyShop.Data/JSONfiles/* JSONfiles/
#ENTRYPOINT ["dotnet", "CandyShop.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CandyShop.dll
