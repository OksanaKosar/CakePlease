using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CakePlease.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Display(Name = "Замовлення")]
        
        [Range(1, 100, ErrorMessage = "Замовлення не може перевищувати 100 і містити від'ємні значення!!")]
        public int DisplayOrder { get; set; }
        public DateTime Created_data_time { get; set; } = DateTime.Now;
    }
}
