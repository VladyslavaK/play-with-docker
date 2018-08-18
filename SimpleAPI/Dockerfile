FROM microsoft/dotnet:2.1.300-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY . ./
RUN dir ./ && dotnet restore


# copy everything else and build app

   # Enable detection of running in a container
ENV  DOTNET_RUNNING_IN_CONTAINER=true \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true 

EXPOSE 54334

# docker inspect -f "{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}" 7bee
CMD dotnet watch --project SimpleAPI/ run 
