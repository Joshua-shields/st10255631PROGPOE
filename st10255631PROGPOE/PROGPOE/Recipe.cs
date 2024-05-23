//**************************************************************START OF iMPORTS*************************************************************//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//**************************************************************END OF IMPORTS**************************************************************//
// Name: Joshua Shields
// Student number: ST10255631
// Group: Group 2

//References: GeeksforGeeks. (2020). C# Tutorial. [online] Available at: https://www.geeksforgeeks.org/c-sharp-tutorial/. [Accessed 20 March]//
//            Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6. Apress.
//            Bro Code (2022). C# Full Course for free 🎮. [online] Available at: https://www.youtube.com/watch?v=wxznTygnRfQ&list=WL&index=1.


namespace RecipeManager
{
    // <summary>
    /// This defines a class Recipe.
    /// That store arrays using strings.
    /// that represents the ingredients, quantities, units, and steps of a recipe.
    /// </summary>
    public class Recipe
    {
        public string Name { get; set; } // Name of the recipe
        public List<Ingredient> Ingredients { get; set; } // List of ingredients
        public List<string> Steps { get; set; } // List of steps


        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// 
        /// </summary>
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();

            //--------------------------------------------------------------------------------------------------------------//
        }
        /// <summary>
        /// Calculates the total calories of the recipe.
        /// </summary>
        /// <returns>The total calories as an integer.</returns>
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }
    }
}



//**************************************************************END OF FILE**************************************************************//