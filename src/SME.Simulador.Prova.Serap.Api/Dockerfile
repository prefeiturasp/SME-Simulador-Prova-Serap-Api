FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/SME.Simulador.Prova.Serap.Api/SME.Simulador.Prova.Serap.Api.csproj", "SME.Simulador.Prova.Serap.Api/"]
COPY ["src/SME.Simulador.Prova.Serap.IoC/SME.Simulador.Prova.Serap.IoC.csproj", "SME.Simulador.Prova.Serap.IoC/"]
COPY ["src/SME.Simulador.Prova.Serap.Infra/SME.Simulador.Prova.Serap.Infra.csproj", "SME.Simulador.Prova.Serap.Infra/"]
COPY ["src/SME.Simulador.Prova.Serap.Dominio/SME.Simulador.Prova.Serap.Dominio.csproj", "SME.Simulador.Prova.Serap.Dominio/"]
COPY ["src/SME.Simulador.Prova.Serap.Dados/SME.Simulador.Prova.Serap.Dados.csproj", "SME.Simulador.Prova.Serap.Dados/"]
RUN dotnet restore "SME.Simulador.Prova.Serap.Api/SME.Simulador.Prova.Serap.Api.csproj"
COPY . .
WORKDIR "/src/src/SME.Simulador.Prova.Serap.Api"
RUN dotnet build "SME.Simulador.Prova.Serap.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SME.Simulador.Prova.Serap.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
ENV TZ=America/Sao_Paulo
RUN apt-get update \
    && apt-get install -yq tzdata locales -y \
    && dpkg-reconfigure --frontend noninteractive tzdata \
	  && locale-gen en_US.UTF-8
	  
RUN sed -i 's/DEFAULT@SECLEVEL=2/DEFAULT@SECLEVEL=1/g' /etc/ssl/openssl.cnf

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SME.Simulador.Prova.Serap.Api.dll"]
