using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//NEEDED TO BE ABLE TO USE: VALIDATIONS, SCHEMA CREATION 


namespace Chefs_n_Dishes.Models
{
    public class Dish
    {
        [Key]//  primary key for Dish table
        public int DishId { get;set; }
        // foreign key of chefid for the one to many relationship
        public int ChefId{ get;set; }
        // linking the chef to the specific dish
        public Chef Chef { get;set; }

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        public string Name {get; set;}

        [Required]
        [Range(0, 100000, ErrorMessage = "Must be more greater than 0.")]
        public int Calories {get; set;}

        [Required]
        [Range(1, 5, ErrorMessage = "Must be more greater than 0 but less than 6.")]
        public int Tastiness {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Must be more than 2 characters.")]
        [MaxLength(200, ErrorMessage = "Must be shorter than 200 characters.")]
        public string Description {get; set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}