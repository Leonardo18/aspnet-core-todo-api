# Aspnet-Core-Todo-Api
C# microservice using ***Aspnet Core*** to provide web api's using a memory database

### Usage
* First thing to do is use the command `docker build -t aspnetapp .` in root folder, this command will build ***Dockerfile*** and download dependencys needed

* After finish the first step, the next step is in root folder run the command `docker run -d -p 8080:80 --name todoapp aspnetapp`, with this, the project can be accessed from url [localhost:8080/api/todo](localhost:8080/api/todo), when accessed this url will show a Todo data, this data was created when project was started

* Now ***Postman*** can be used to make get, get/{id}, post, put and delete

### Acknowledgments
* [AspNet Core documentation](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.1)
