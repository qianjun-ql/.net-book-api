using Microsoft.EntityFrameworkCore;
using BookServicesApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace BookServicesApi.Data {
    public class BookWebApiContext : IdentityDbContext<User> {
        public BookWebApiContext(DbContextOptions<BookWebApiContext> options) 
            : base(options) { }

            public DbSet<Author> Authors {get;set;} = default;
            public DbSet<Book> Books {get;set;} 
            // public DbSet<Genre> Genres {get;set;}
            public DbSet<BookOrder> BookOrder {get;set;}
        // public DbSet<OrderItem> OrderItem {get;set;}
        // public DbSet<Employee> Employee {get;set;}
        // public DbSet<Product> Product {get;set;}
        // public DbSet<State> State {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookOrder>()
            .HasOne(b => b.Book)
            .WithMany()
            .HasForeignKey(b => b.BookId);
        }
    }
    }