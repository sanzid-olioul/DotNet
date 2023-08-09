using System.ComponentModel.DataAnnotations;

namespace WebTest1.Models
{
    public enum LaptopTpe{First,Secound,Third}
    public class Laptop
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        public LaptopTpe laptopTpe { get; set; }
        public int Ram { get; set; }

    }
}
