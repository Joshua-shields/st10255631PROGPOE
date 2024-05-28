//**************************************************************START OF IMPORTS*****************************************************//
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeManager;
using System;
//**************************************************************END OF IMPORTS*****************************************************//
// Name: Joshua Shields
// Student number: ST10255631
// Group: Group 2

//References: GeeksforGeeks. (2020). C# Tutorial. [online] Available at: https://www.geeksforgeeks.org/c-sharp-tutorial/. [Accessed 20 March]
//            Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6. Apress.
//            Bro Code (2022). C# Full Course for free 🎮. [online] Available at: https://www.youtube.com/watch?v=wxznTygnRfQ&list=WL&index=1.

// GITHUB LINK: https://github.com/Joshua-shields/st10255631PROGPOE.git

namespace RecipeManagerTests
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void CalculateTotalCalories_EmptyRecipe_ReturnsZero()
        {
            Recipe recipe = new Recipe(); // Recipe with a constructor to initialise Ingredients

            int totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(0, totalCalories);
        }

        [TestMethod]
        public void CalculateTotalCalories_SingleIngredient_ReturnsCorrectCalories()
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 100 }); // Only the calories matter for this test

            int totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(100, totalCalories);
        }

        [TestMethod]
        public void CalculateTotalCalories_MultipleIngredients_ReturnsSumOfCalories()
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 50 });
            recipe.Ingredients.Add(new Ingredient { Calories = 75 });

            int totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(125, totalCalories);
        }

        [TestMethod]
        public void CalculateTotalCalories_IngredientWithZeroCalories_IgnoresIngredient()
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 0 });
            recipe.Ingredients.Add(new Ingredient { Calories = 150 });

            int totalCalories = recipe.CalculateTotalCalories();

            Assert.AreEqual(150, totalCalories);
        }
    }
}