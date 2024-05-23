//**************************************************************START OF IMPORTS*****************************************************//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//**************************************************************END OF IMPORTS**************************************************************//
// Name: Joshua Shields
// Student number: ST10255631
// Group: Group 2

//References: GeeksforGeeks. (2020). C# Tutorial. [online] Available at: https://www.geeksforgeeks.org/c-sharp-tutorial/. [Accessed 20 March]
//            Troelsen, A. and Japikse, P. (2022). Pro C# 10 with .NET 6. Apress.
//            Bro Code (2022). C# Full Course for free 🎮. [online] Available at: https://www.youtube.com/watch?v=wxznTygnRfQ&list=WL&index=1.


namespace RecipeManager
{
    public static class Input
    {
        /// <summary>
        /// Gets an integer input from the user.
        /// </summary>
        /// <param name="message">The prompt message to display to the user.</param>
        /// <returns>The integer value entered by the user.</returns>
        public static int GetIntegerInput(string message)
        {
            int value;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out value));
            return value;
        }
        //--------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Gets a string input from the user.
        /// </summary>
        /// <param name="message">The prompt message to display to the user.</param>
        /// <returns>The string value entered by the user.</returns>
        public static bool GetConfirmation(string action)
        {
            Console.Write($"Are you sure you want to {action}? (y/n) ");
            string input = Console.ReadLine().ToLower();

            while (input != "y" && input != "n")
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                Console.Write($"Are you sure you want to {action}? (y/n) ");
                input = Console.ReadLine().ToLower();
            }

            return input == "y";
        }

        internal static string GetStringInput(string v)
        {
            throw new NotImplementedException();
        }
    }
}


//**************************************************************END OF FILE**************************************************************//