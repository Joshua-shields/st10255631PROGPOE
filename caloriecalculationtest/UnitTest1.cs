using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeManager;

namespace RecipeManagerTests // Choose a suitable namespace
{
    [TestClass]
    public class RecipeTests
    {
        [TestMethod]
        public void CalculateTotalCalories_EmptyRecipe_ReturnsZero()
        {
            // Arrange
            Recipe recipe = new Recipe();

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(0, totalCalories);
        }

        [TestMethod]
        public void CalculateTotalCalories_MultipleIngredients_ReturnsCorrectSum()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 50 });
            recipe.Ingredients.Add(new Ingredient { Calories = 100 });
            recipe.Ingredients.Add(new Ingredient { Calories = 75 });

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(225, totalCalories);
        }

        [TestMethod]
        public void CalculateTotalCalories_IngredientWithZeroCalories_DoesNotAffectTotal()
        {
            // Arrange
            Recipe recipe = new Recipe();
            recipe.Ingredients.Add(new Ingredient { Calories = 100 });
            recipe.Ingredients.Add(new Ingredient { Calories = 0 });

            // Act
            int totalCalories = recipe.CalculateTotalCalories();

            // Assert
            Assert.AreEqual(100, totalCalories);
        }

        [TestMethod]
        public void CalculateTotalCalories_Exceeds300_TriggersCalorieLimitEvent()
        {
            // Arrange
            Recipe recipe = new Recipe { Name = "High-Calorie Recipe" };
            recipe.Ingredients.Add(new Ingredient { Calories = 200 });
            recipe.Ingredients.Add(new Ingredient { Calories = 150 });

            bool eventTriggered = false;
            recipe.CalorieLimitExceeded += (r) => eventTriggered = true;

            // Act
            recipe.CalculateTotalCalories();

            // Assert
            Assert.IsTrue(eventTriggered);
        }
    }
}