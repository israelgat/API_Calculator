# ===== STAGE 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# נעתיק רק את ה-csproj ונבצע restore (שכבת cache יעילה)
COPY IO.Swagger.csproj ./
RUN dotnet restore

# עכשיו נעתיק את כל הקוד ונבצע publish ל-Release
COPY . .
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# ===== STAGE 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# ב-.NET 8 ה-runtime מאזין כברירת מחדל על 8080 בתוך הקונטיינר
EXPOSE 8080

# השאר כתגובה כדי לשלוט בזה מבחוץ; נזרים דרך docker run:
# ENV ASPNETCORE_ENVIRONMENT=Development

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "IO.Swagger.dll"]
