
using ChhotaNivesh.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace ChhotaNivesh.DBCore
{
    public class DBContextFD : DbContext
    {

        public DBContextFD()
        { }
        public DBContextFD(DbContextOptions<DBContext> options)
            : base(options)
        { }
        public virtual DbSet<Users> Users { get; set; }
		
		protected override void OnModelCreating(ModelBuilder builder)
        {
          //  base.OnModelCreating(builder);
            builder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).HasColumnName("UserId");
              
            });

           


        }
    }
}
