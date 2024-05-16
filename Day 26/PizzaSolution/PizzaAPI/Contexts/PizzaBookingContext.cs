using Microsoft.EntityFrameworkCore;
using PizzaAPI.Models;

namespace PizzaAPI.Contexts
{
    public class PizzaBookingContext :DbContext
    {
        public PizzaBookingContext(DbContextOptions<PizzaBookingContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza()
                {
                    PizzaId = 101,
                    Name = "Margherita Pizza",
                    Description = "" +
                "Pizza topped with our herb infused signature",
                    AvailableStock = 4,
                    Status = true
                },
                new Pizza()
                {
                    PizzaId = 102,
                    Name = "Fiery Sausage & Paprika Pizza",
                    Description = "" +
                "Spiciest non veg pizza with spicy & herby chicken sausage and red " +
                "paprika toppings on a new spicy peri peri sauce base.",
                    AvailableStock = 3,
                    Status = true
                },
                new Pizza()
                {
                    PizzaId = 103,
                    Name = "Spiced Double Chicken Pizza",
                    Description = "" +
                    "Delightful combination of our spicy duo- Pepper Barbecue Chicken and " +
                    "Peri Peri Chicken for Chicken Lovers.",
                    AvailableStock = 8,
                    Status = true
                }
                );
        }

    }
}
