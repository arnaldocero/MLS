using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MLS.Web.Data.Entities;

namespace MLS.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<DocumentoEntity> Documento { get; set; }
        
    }
}
