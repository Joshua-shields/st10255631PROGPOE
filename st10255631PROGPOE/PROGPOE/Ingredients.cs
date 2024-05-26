//**************************************************************START OF IMPORTS*****************************************************//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//**************************************************************END OF IMPORTS*****************************************************//
// Name: Joshua Shields
// Student number: ST10255631
// Group: Group 2

//References: GeeksforGeeks. (2020). C# Tutorial. [online] Available at: https://www.geeksforgeeks.org/c-sharp-tutorial/. [Accessed 20 March]
//            Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6. Apress.
//            Bro Code (2022). C# Full Course for free 🎮. [online] Available at: https://www.youtube.com/watch?v=wxznTygnRfQ&list=WL&index=1.

namespace RecipeManager
{
    public class Ingredient
    {
        public string Name { get; set; }         // Name of the ingredient
        public string Quantity { get; set; }      // Quantity of the ingredient
        public string Unit { get; set; }          // Unit of measurement for the ingredient
        public int Calories { get; set; }        // Calories in the ingredient
        public string FoodGroup { get; set; }    // Food group the ingredient belongs to
        public string OriginalQuantity { get; internal set; } // the original Quantity before scaling
    }
}
//**************************************************************END OF FILE**************************************************************//