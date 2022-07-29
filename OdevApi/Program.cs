using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OdevApi.Base.Execption;
using OdevApi.Data.Context;
using System.Net;

var builder = WebApplication.CreateBuilder(args);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DefaultModelsExpandDepth(-1); // Remove Schema on Swagger UI
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patika");
        c.DocumentTitle = "Patika";
    });
}

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (contextFeature != null)
        {
            await context.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error. App Level."
            }.ToString());
        }
    });
});

app.UseHttpsRedirection();


app.UseRouting();


app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
