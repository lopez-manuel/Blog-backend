using Microsoft.EntityFrameworkCore;

namespace Blog;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    //SETTING SERVICES
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthorization();

        var connectionStringDb = Configuration["DB:connectionString"];

        services.AddDbContext<ContextDb>(opt => opt.UseNpgsql(connectionStringDb));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
        
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
    }
}