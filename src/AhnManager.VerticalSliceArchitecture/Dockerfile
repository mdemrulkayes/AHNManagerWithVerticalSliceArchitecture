#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/AhnManager.VerticalSliceArchitecture/AhnManager.VerticalSliceArchitecture.csproj", "src/AhnManager.VerticalSliceArchitecture/"]
RUN dotnet restore "./src/AhnManager.VerticalSliceArchitecture/./AhnManager.VerticalSliceArchitecture.csproj"
COPY . .
WORKDIR "/src/src/AhnManager.VerticalSliceArchitecture"
RUN dotnet build "./AhnManager.VerticalSliceArchitecture.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AhnManager.VerticalSliceArchitecture.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AhnManager.VerticalSliceArchitecture.dll"]