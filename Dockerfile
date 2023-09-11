FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
COPY . .
RUN dotnet restore 
RUN dotnet publish -c Release -o /app/deploy
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/deploy /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENTRYPOINT [ "dotnet", "/app/tadbirInsuranceApi.dll" ]

