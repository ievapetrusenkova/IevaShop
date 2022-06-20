using IevaShop.Context.Entity;
using System.ComponentModel.DataAnnotations;

namespace IevaShop.Models
{
    public class CreateClothingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }

    }
}
