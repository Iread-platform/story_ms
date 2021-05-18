FROM mcr.microsoft.com/dotnet/sdk:5.0

MAINTAINER Yazan Kassam, yazankassam.codavia@gmail.com

WORKDIR /app

ENV ASPNETCORE_URLS="http://story_ms:5000"

ENV ASPNETCORE_ENVIRONMENT=Development

ENV ConnectionStrings:DefaultConnection="Server=story_ms_db;Database=story_ms_db;Uid=codavia;Pwd=cod@v!@; convert zero datetime=True"

ENV ConsulConfig:Host="http://consul:8500"

EXPOSE 5000

COPY ./publish .

ENTRYPOINT ["dotnet","iread_story.dll"]
