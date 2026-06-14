FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app
COPY ./Assemblies/ ./
COPY DFast.Seguridad.Api/*.csproj ./
RUN dotnet restore
COPY DFast.Seguridad.Api/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV TZ=America/Guayaquil
ARG environment=development
ENV ASPNETCORE_ENVIRONMENT=$environment
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DFast.Seguridad.Api.dll"]