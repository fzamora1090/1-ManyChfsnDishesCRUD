using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//NEEDED TO BE ABLE TO USE: VALIDATIONS, SCHEMA CREATION 

namespace Chefs_n_Dishes.Models
{
    public class Chef
    {
        [Key] // Primary key on this table
        public int ChefId { get;set; }
        //1-many foriegn key injection !!!! Key goes on the MANY!! not the 1...
        [Required(ErrorMessage = "is required!")]
        [MinLength(2, ErrorMessage = "Must be longer than 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get;set; }

        [Required(ErrorMessage = "is required!")]
        [MinLength(2, ErrorMessage = "Must be longer than 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get;set; }

        [Required(ErrorMessage = "is required!")]
        [DateMinimumAge(18, ErrorMessage="{0} must be someone at least {1} years of age")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Date_of_Birth { get;set; }
        // public Nullable<System.DateTime> Date_of_Birth { get;set; }



        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // navigation property for the relationship
        public List<Dish> Dishes { get; set; } // 1 user: M // 1-Chef -- M-Dishes relationship
        
        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public int Age(DateTime? Date_of_Birth)
        {
            int age = 0;  
            age = DateTime.Now.Year - Date_of_Birth.Value.Year;  
            // if (DateTime.Now.DayOfYear < Date_of_Birth.Value.DayOfYear)  
            //     age = age - 1;  
            Console.WriteLine(DateTime.Now.Year);
            Console.WriteLine(Date_of_Birth.Value.Year);
            
            return age;

            // if (Date_of_Birth.HasValue)
            // {
            //     int age = 0;  
            //     age = DateTime.Now.Year - Date_of_Birth.Value.Year;  
            //     if (DateTime.Now.DayOfYear < Date_of_Birth.Value.DayOfYear)  
            //         age = age - 1;  
            
            //     return age;
            // }
            // else
            // {
            //     return 0;
            // }
            
        }

    }
}