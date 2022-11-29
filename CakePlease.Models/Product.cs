using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakePlease.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Display(Name = "Опис")]
        public string Description { get; set; }

        [Required]
        [Range(1,2000)]
        [Display(Name = "Ціна")]
        public double Price { get; set; }
        [ValidateNever]
        [Display(Name = "Зображення")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Категорія")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Упаковка")]
        public int CoverTypeId { get; set; }
        [ValidateNever]

        public CoverType CoverType { get; set; }
    }
}
