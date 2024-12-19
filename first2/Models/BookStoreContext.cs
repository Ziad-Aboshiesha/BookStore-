using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace first2.Models
{
    public class BookStoreContext : IdentityDbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Order_details> Order_Details { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }



        public BookStoreContext(DbContextOptions<BookStoreContext> db):base(db)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order_details>().HasKey(k => new { k.order_id , k.book_id });
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole("admin"), new IdentityRole("customer"));
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "customer",
                    NormalizedName = "CUSTOMER"
                }
            );

        }
    }
}
