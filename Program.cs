using Microsoft.EntityFrameworkCore;

namespace Blog;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // var stringC = "Server=ep-curly-dawn-36053569.us-east-2.aws.neon.tech; Port:5432; User Id=lopez.ledezma.manuel; Password=X2J6KoutmWHi;";

        var connectionStringDb = builder.Configuration["DB:connectionString"];

        builder.Services.AddDbContext<ContextDb>(opt => opt.UseNpgsql(connectionStringDb));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}