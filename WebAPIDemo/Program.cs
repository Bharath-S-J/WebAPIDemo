var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});



var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();


app.MapControllers();




app.Run();

