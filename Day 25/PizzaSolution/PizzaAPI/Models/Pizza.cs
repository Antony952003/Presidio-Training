using System.ComponentModel.DataAnnotations;

namespace PizzaAPI.Models
{
    public class Pizza
    {
        [Key]
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AvailableStock { get; set; }
        public bool Status { get; set; }
    }
}
