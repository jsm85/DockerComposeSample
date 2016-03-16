FROM microsoft/aspnet:1.0.0-rc1-update1

COPY . /app
WORKDIR /app
RUN ["dnu", "restore"]
RUN ["dnu", "build"]

EXPOSE 5000/tcp
ENTRYPOINT ["dnx", "run"]
