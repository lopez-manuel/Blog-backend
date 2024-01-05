

using Blog.Models;
using Microsoft.EntityFrameworkCore;

public class ContextDb: DbContext
{
    public DbSet<Categoria> Categorias { get; set; }

    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
        
    }
}