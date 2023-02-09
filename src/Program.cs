using IRecepiesApp.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();

app.MapMethods(GetIngredientsByName.Template, GetIngredientsByName.Methods, GetIngredientsByName.Handle);
app.MapMethods(GetRecepiesByIngredient.Template, GetRecepiesByIngredient.Methods, GetRecepiesByIngredient.Handle);
app.MapMethods(GetReletatedRecepiesById.Template, GetReletatedRecepiesById.Methods, GetReletatedRecepiesById.Handle);

app.Run();
