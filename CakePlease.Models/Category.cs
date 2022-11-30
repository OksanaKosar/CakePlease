﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CakePlease.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Order")]
        
        [Range(1, 100, ErrorMessage = "Display order must be between 1 and 100 only!")]
        public int DisplayOrder { get; set; }
        public DateTime Created_data_time { get; set; } = DateTime.Now;
    }
}
