using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class Ingredient
    {
        public string Name { get; set; }         // Name of the ingredient
        public string Quantity { get; set; }      // Quantity of the ingredient
        public string Unit { get; set; }          // Unit of measurement for the ingredient
        public int Calories { get; set; }        // Calories in the ingredient
        public string FoodGroup { get; set; }    // Food group the ingredient belongs to
    }
}