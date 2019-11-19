using System;
using System.ComponentModel.DataAnnotations;
using ChefsDishes.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        [Required]
        [Column("id", TypeName="INT(11)")]
        public int DishId {get;set;}
       
        [Required]
        [Display(Name = "Name of Dish")]
        [Column("dish_name", TypeName="VARCHAR(40)")]
        public string Name {get;set;}

        [Required]
        [Display(Name= "Deliciousness Rating")]
        [Column("taste_rating", TypeName="INT(1)")]
        public int Tastiness {get;set;}

        [Required]
        [Display(Name = "# of Calories")]
        [Range(1,9999)]
        [Column("calorie_amount", TypeName="INT(4)")]
        public int Calories {get;set;}

        [Required]
        [Column("description", TypeName="TEXT")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        public Chef Creator {get;set;}

        [Column("ChefId", TypeName="INT(11)")]
        [Display(Name = "Chef's Name")]
        public int ChefId {get;set;}
    }
}
