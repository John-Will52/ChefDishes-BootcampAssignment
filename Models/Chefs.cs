using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ChefsDishes.Models
{
    public class Chef
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        [Column ("id", TypeName="INT(11)")]
        
        public int ChefId { get; set; }

        [Required]
        [Column ("first_name", TypeName="VARCHAR(40)")]
        [Display(Name = "Chef's First Name")]
        public string FirstName { get; set; }

        [Required]
        [Column ("last_name", TypeName="VARCHAR(40)")]
        [Display(Name = "Chef's Last Name")]
        public string LastName { get; set; }
       
        [Required]
        [Column ("birthdate")]
        [Display(Name = "Chef's Birthdate")]
        public DateTime Birthdate {get;set;}

        [Column ("created_at")]
        public DateTime CreatedAt {get;set;} = DateTime.Now;

        [Column ("updated_at")]
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public List<Dish> Recipes {get;set;}

        public int Age(DateTime Birthdate)
        {
            var currently = DateTime.Now;
            int age = (int)currently.Year - (int)Birthdate.Year;
            return age;
        }
    }
}    