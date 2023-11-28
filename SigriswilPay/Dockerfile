FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SigriswilPay/SigriswilPay.csproj", "SigriswilPay/"]
RUN dotnet restore "SigriswilPay/SigriswilPay.csproj"
COPY . .
WORKDIR "/src/SigriswilPay"
RUN dotnet build "SigriswilPay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SigriswilPay.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SigriswilPay.dll"]
