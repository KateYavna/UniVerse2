using UniVerse.Models;
using UniVerse.Services.Interfaces;
using UniVerse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IPostService, PostService>();
var configuration = builder.Configuration;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/api/clients", async (IClientService clientService) => await clientService.GetClientList());
app.MapGet("/api/client/{id}", async (IClientService clientService, int clientId) => await clientService.GetClient(clientId));
app.MapPost("/api/client", async (IClientService clientService, Client client) => await clientService.CreateClient(client));
app.MapPut("/api/client", async (IClientService clientService, Client client) => await clientService.UpdateClient(client));
app.MapDelete("/api/client/{id}", async (IClientService clientService, int clientId) => await clientService.DeleteClient(clientId));

app.MapGet("/api/posts", async (IPostService postService) => await postService.GetPostList());
app.MapGet("/api/post/{id}",async (IPostService postService, int postId) => await postService.GetPost(postId));
app.MapPost("/api/post", async (IPostService postService, Post post) => await postService.CreatePost(post));
app.MapPut("/api/post", async (IPostService postService, Post post) => await postService.UpdatePost(post));
app.MapDelete("/api/post/{id}", async (IPostService postService, int postId) => await postService.DeletePost(postId));

app.Run();