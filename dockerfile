FROM mcr.microsoft.com/dotnet/sdk:9.0 as build

WORKDIR /src

copy . .

RUN dotnet restore

RUN dotnet publish EmployeeManagament.Api.csproj --no-restore -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:9.0 

WORKDIR /app

copy --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet","EmployeeManagament.Api.dll"]


