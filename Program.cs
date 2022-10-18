using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using TodoListGQL.Data;
using TodoListGQL.GraphQL;
using TodoListGQL.GraphQL.Items;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<ApiDbContext>(options =>
    options.UseSqlite(
        configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddGraphQLServer().AddQueryType<Query>().AddType<ItemType>().AddType<ListType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddMutationType<Mutation>()
    .AddInMemorySubscriptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// app.MapGraphQL("/graphql");

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-voyager");

app.UseWebSockets();

app.Run();
