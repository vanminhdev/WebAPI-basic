namespace WebAPIDemo;

public class Program
{


    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1",
                new Microsoft.OpenApi.OpenApiInfo { Title = "Demo Web API", Version = "v1" }
            );
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo API V1");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        // Map student CRUD endpoints (minimal API)
        app.MapStudentApi();

        // Map controller endpoints (attribute routing)
        app.MapControllers();

        app.Run();
    }
}
