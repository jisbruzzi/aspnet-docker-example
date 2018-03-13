#take a base image from the public dockerhub repositories
FROM microsoft/dotnet:2.0.0-sdk 

#navigate to the /app folder
WORKDIR /app 

#copy the .csproj file to the /app folder
COPY *.csproj ./ 

#Download the dependencies listed in the .csproj file
RUN dotnet restore 

#copy all files in the project folder, except the ones stated in .dockerignore
COPY . ./ 
