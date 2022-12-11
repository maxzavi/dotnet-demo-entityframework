FROM mcr.microsoft.com/dotnet/aspnet:6.0
EXPOSE 80
WORKDIR /app
COPY  . /app/.
ENV TZ=America/New_York
ENTRYPOINT ["dotnet", "wa-sample.dll"]