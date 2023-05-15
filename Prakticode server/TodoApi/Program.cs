using TodoApi;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


 builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

builder.Services.AddSingleton<TodosService>();
builder.Services.AddSingleton<ToDoDbContext>();

var app = builder.Build();

app.UseCors();
 app.UseSwagger();

 app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapGet("/getAll",async (TodosService serv)=> await serv.GetAll());
app.MapPost("/post",async (TodosService serv,Item item)=> await serv.Post(item));
app.MapPut("/update/{id}",async (TodosService serv,int id,Item item)=> await serv.Update(id,item));
app.MapDelete("/delete/{id}", async (TodosService serv,int id)=> await serv.Delete(id));

app.Run();

