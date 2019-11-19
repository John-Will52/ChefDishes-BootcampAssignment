using System;
using System.ComponentModel.DataAnnotations;
using ChefsDishes.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsDishes.Models
{
    public class IndexViewModel
    {
        public Dish NewDish{get;set;}
        public Chef ChefList{get;set;}
    }
}