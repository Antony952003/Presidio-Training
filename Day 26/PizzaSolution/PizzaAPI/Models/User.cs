using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace PizzaAPI.Models
{
   // 3) Create an API that will allow user to login in a application that
   // the user can order pizzas. (Sample Dominos/PizzaHut)
   //Add an end-point that will list the pizza.List only those pizza's that are in stock.
   //Device the model and DTOs as well.
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }

    }
}
