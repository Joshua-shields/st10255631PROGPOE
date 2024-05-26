//**************************************************************START OF IMPORTS*****************************************************//
using RecipeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
//**************************************************************END OF IMPORTS*****************************************************//
// Name: Joshua Shields
// Student number: ST10255631
// Group: Group 2

//References: GeeksforGeeks. (2020). C# Tutorial. [online] Available at: https://www.geeksforgeeks.org/c-sharp-tutorial/. [Accessed 20 March]//
//            Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6. Apress.
//            Bro Code (2022). C# Full Course for free 🎮. [online] Available at: https://www.youtube.com/watch?v=wxznTygnRfQ&list=WL&index=1.

namespace RecipeManager
{
    public delegate void CalorieLimitExceededHandler(Recipe recipe);
    public class RecipeCollection
    {
        public List<Recipe> Recipes { get; private set; }  // List to store all recipes
        public event CalorieLimitExceededHandler CalorieLimitExceeded; // Event to notify about exceeding calorie limit

        /// <summary>
        /// Constructor for the RecipeCollection class. Initialises the Recipes list.
        /// </summary>
        public RecipeCollection()
        {
            Recipes = new List<Recipe>();
            CalorieLimitExceeded += HandleCalorieLimitExceeded; // Subscribe to the event
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Greets the user by displaying a welcome message and then it prompts them to enter their name.
        /// Once the name is entered it then displays the greeting along with their name.
        /// </summary>
        public void GreetUser()
        {
            Console.ForegroundColor = ConsoleColor.Green; // Change the text color to green
            Console.WriteLine("Welcome to the Recipe Application!");
            Console.ResetColor(); // Reset the text color to the default

            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello, {name}!");
            Console.WriteLine();
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Adds a new recipe to the collection by prompting the user for recipe details.
        /// </summary>
        public void AddRecipe()
        {
            Recipe newRecipe = new Recipe();

            Console.WriteLine("Enter the recipe name: ");
            newRecipe.Name = Console.ReadLine();

            int ingredientCount = Input.GetIntegerInput("Please Enter the number of ingredients: ");
            for (int i = 0; i < ingredientCount; i++)
            {
                Ingredient ingredient = new Ingredient();
                Console.WriteLine($"\nEnter ingredient {i + 1} details:");
                ingredient.Name = Input.GetStringInput("Name: ");
                ingredient.Unit = Input.GetStringInput("Unit (tsp, tbsp, cup, oz, lb, g, kg, ml, l, quart, gallon, pinch, unit): ");
                ingredient.Quantity = Input.GetStringInput("Quantity: ");
                ingredient.Calories = Input.GetIntegerInput("Calories: ");

                // Food Group Selection
                Console.WriteLine("Select Food Group:");
                Console.WriteLine("1. Protein, such as steak, poultry, or fish");
                Console.WriteLine("2. Carbohydrates, such as potatoes, bread, or flour");
                Console.WriteLine("3. Fats, such as olive oil, avocado, or butter");
                Console.WriteLine("4. Fruits, such as apples, oranges, or grapes");
                Console.WriteLine("5. Vegetables, such as broccoli, kale, or cabbage");
                Console.WriteLine("6. Dairy, such as milk, cream, or yoghurt");
                Console.WriteLine("7. Sweets, such as chocolate, sugar, or icing");


                int foodGroupChoice = Input.GetIntegerInput("Enter your choice: ");

                switch (foodGroupChoice)
                {
                    case 1: ingredient.FoodGroup = "Protein"; break;
                    case 2: ingredient.FoodGroup = "Carbohydrates"; break;
                    case 3: ingredient.FoodGroup = "Fats"; break;
                    case 4: ingredient.FoodGroup = "Fruits"; break;
                    case 5: ingredient.FoodGroup = "Vegetables"; break;
                    case 6: ingredient.FoodGroup = "Dairy"; break;
                    case 7: ingredient.FoodGroup = "Sweets"; break;
                    default: ingredient.FoodGroup = "Other"; break; // Handles invalid choices
                }

                newRecipe.Ingredients.Add(ingredient);
            }

            int stepCount = Input.GetIntegerInput("Please Enter the number of steps: ");
            Console.WriteLine("\nEnter the steps for the recipe:");
            for (int i = 0; i < stepCount; i++)
            {
                newRecipe.Steps.Add(Input.GetStringInput($"Step {i + 1}: "));
            }

            Recipes.Add(newRecipe);

            // Check if the total calories exceed 300 and raise the event if necessary
            if (newRecipe.CalculateTotalCalories() > 300)
            {
                OnCalorieLimitExceeded(newRecipe);
            }
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Displays a list of all recipes in alphabetical order, allowing the user to choose one to display in detail.
        /// </summary>
        public void DisplayRecipes()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.WriteLine("\nAvailable Recipes:");
            var sortedRecipes = Recipes.OrderBy(r => r.Name).ToList(); // Sort recipes alphabetically

            for (int i = 0; i < sortedRecipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");
            }

            int choice = Input.GetIntegerInput("\nChoose a recipe to display: ") - 1;

            if (choice >= 0 && choice < sortedRecipes.Count)
            {
                DisplayRecipeDetails(sortedRecipes[choice]);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Displays the details of a specific recipe, including ingredients, steps, and total calories.
        /// </summary>
        /// <param name="recipe">The Recipe object to display.</param>
        private void DisplayRecipeDetails(Recipe recipe)
        {
            Console.WriteLine($"\n{recipe.Name}");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIngredients:");
            Console.ResetColor();
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSteps:");
            Console.ResetColor();
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
            }

            int totalCalories = recipe.CalculateTotalCalories();
            Console.WriteLine($"\nTotal Calories: {totalCalories}");
        }

        //--------------------------------------------------------------------------------------------------------------//

        public void ScaleRecipe()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to scale.");
                return;
            }

            DisplayRecipeListWithNumbers();

            int choice = Input.GetIntegerInput("\nChoose a recipe to scale: ") - 1;

            if (choice >= 0 && choice < Recipes.Count)
            {
                double scaleFactor = GetScaleFactor();
                ScaleIngredients(Recipes[choice], scaleFactor);

                // Ask if the user wants to reset to original values
                if (Input.GetConfirmation("reset the quantities to the original values"))
                {
                    ResetIngredients(Recipes[choice]); // this call the reset method
                    Console.WriteLine("Quantities reset to original values.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Scales the quantities of ingredients in a given recipe by a specified factor.
        /// </summary>
        /// <param name="recipe">The Recipe object to scale.</param>
        /// <param name="factor">The factor by which to scale the quantities.</param>
        private void ScaleIngredients(Recipe recipe, double factor)
        {
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                double quantity;
                if (double.TryParse(ingredient.Quantity, out quantity))
                {
                    quantity *= factor;
                    ingredient.Quantity = quantity.ToString();

                    // Unit Conversion (Example: Tablespoons to Cups)
                    if (ingredient.Unit == "tbsp" && quantity >= 16)
                    {
                        ingredient.Unit = "cup";
                        ingredient.Quantity = (quantity / 16).ToString(); //  1 cup = 16 tbsp
                    }

                }
            }

            Console.WriteLine($"Recipe '{recipe.Name}' scaled by a factor of {factor}.");
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Resets the quantities of ingredients in a recipe to their original values.
        /// </summary>
        /// <param name="recipe">The Recipe object to reset.</param>
        private void ResetIngredients(Recipe recipe)
        {
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Clears all recipes from the collection after confirming with the user.
        /// </summary>
        public void ClearRecipes()
        {
            if (Recipes.Count == 0)
            {
                Console.WriteLine("No recipes to clear.");
                return;
            }

            if (Input.GetConfirmation("clear all recipes"))
            {
                Recipes.Clear();
                Console.WriteLine("All recipes cleared.");
            }
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Displays a numbered list of all recipes in the collection.
        /// </summary>
        private void DisplayRecipeListWithNumbers()
        {
            Console.WriteLine("\nAvailable Recipes:");
            for (int i = 0; i < Recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Recipes[i].Name}");
            }
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Prompts the user to enter a valid scale factor for scaling recipe quantities.
        /// Validates the input to ensure it falls within the acceptable range (0.5 to 3.0).
        /// </summary>
        /// <returns>The valid scale factor entered by the user.</returns>
        private double GetScaleFactor()
        {
            double factor;
            do
            {
                Console.Write("Enter the scale factor (0.5 to half, 2 to double, 3 to triple): ");
            } while (!double.TryParse(Console.ReadLine(), out factor) || factor < 0.5 || factor > 3);

            return factor;
        }

        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Displays the main menu and handles user interaction for managing recipes.
        /// Allows the user to add, display, scale, and clear recipes, as well as exit the application.
        /// </summary>
        public void Menu()
        {
            GreetUser();

            int choice;

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRecipe Manager Menu:");
                Console.ResetColor();

                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. Display Recipes");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Clear Recipes");
                Console.WriteLine("5. Exit");

                choice = Input.GetIntegerInput("Enter your choice: ");

                switch (choice)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        DisplayRecipes();
                        break;
                    case 3:
                        ScaleRecipe();
                        break;
                    case 4:
                        ClearRecipes();
                        break;
                    case 5:
                        Console.WriteLine("Exiting Recipe Manager. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 5);
        }

        /// <summary>
        /// Raises the CalorieLimitExceeded event if it has subscribers.
        /// </summary>
        /// <param name="recipe">The recipe that exceeded the calorie limit.</param>
        protected virtual void OnCalorieLimitExceeded(Recipe recipe)
        {
            CalorieLimitExceeded?.Invoke(recipe);
        }

        /// <summary>
        /// Event handler for when the total calories of a recipe exceed 300.
        /// </summary>
        /// <param name="recipe">The Recipe object that triggered the event.</param>
        static void HandleCalorieLimitExceeded(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nWarning: Recipe '{recipe.Name}' exceeds 300 calories!");
            Console.WriteLine($"The recipe contains {recipe.CalculateTotalCalories()} calories.");
            Console.ResetColor();
        }
    }
}

//--------------------------------------------------------------------------------------------------------------//



//**************************************************************END OF FILE**************************************************************//