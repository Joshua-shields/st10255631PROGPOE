//**************************************************************START OF IMPORTS*****************************************************//
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeManager;
using System;
using static System.Net.Mime.MediaTypeNames;
//**************************************************************END OF IMPORTS*****************************************************//
// Name: Joshua Shields
// Student number: ST10255631
// Group: Group 2

//References: 
// GeeksforGeeks. (2020). C# Tutorial. [online] Available at: https://www.geeksforgeeks.org/c-sharp-tutorial/. [Accessed 20 March]
// Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6. Apress.
// Bro Code (2022). C# Full Course for free 🎮. [online] Available at: https://www.youtube.com/watch?v=wxznTygnRfQ&list=WL&index=1.

// GITHUB LINK: https://github.com/Joshua-shields/st10255631PROGPOE.git

namespace RecipeManagerTests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        //Test method to ensure CalculateTotalCalories returns 0 when the recipe has no ingredients
        public void CalculateTotalCalories_EmptyRecipe_ReturnsZero()
        {
            Recipe recipe = new Recipe();

            int totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(0, totalCalories);
        }
        //--------------------------------------------------------------------------------------------------------------//


        [TestMethod]
        //Test method to verify CalculateTotalCalories returns the correct calorie count for a recipe with a single ingredient
        public void CalculateTotalCalories_SingleIngredient_ReturnsCorrectCalories()
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 100 });

            int totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(100, totalCalories);
        }
        //--------------------------------------------------------------------------------------------------------------//


        [TestMethod]
        //Test method to validate CalculateTotalCalories correctly sums the calories for a recipe with multiple ingredients
        public void CalculateTotalCalories_MultipleIngredients_ReturnsSumOfCalories()
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 50 });
            recipe.Ingredients.Add(new Ingredient { Calories = 75 });

            int totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(125, totalCalories);
        }
        //--------------------------------------------------------------------------------------------------------------//


        [TestMethod]
        //Test method to confirm CalculateTotalCalories ignores ingredients with 0 calories
        public void CalculateTotalCalories_IngredientWithZeroCalories_IgnoresIngredient()
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 0 });
            recipe.Ingredients.Add(new Ingredient { Calories = 150 });

            int totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(150, totalCalories);
            //--------------------------------------------------------------------------------------------------------------//

        }
        [TestMethod]
        //Test method to verify CalculateTotalCalories throws an ArgumentException if any ingredient has negative calories
        public void CalculateTotalCalories_NegativeCalories_ThrowsArgumentException()
        {
        
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = -50 });

      
            Assert.ThrowsException<ArgumentException>(() => recipe.CalculateTotalCalories());
        //--------------------------------------------------------------------------------------------------------------//

        }
    }
}