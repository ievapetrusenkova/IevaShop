using System.ComponentModel.DataAnnotations;

namespace IevaShop.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]

        [StringLength(100)]

        public string Name { get; set; }
        public List<ClothingModel> AllClothings { get; set; }

    }
}
