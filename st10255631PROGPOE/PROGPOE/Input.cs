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

// GITHUB LINK: https://github.com/Joshua-shields/st10255631PROGPOE.git

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

        //Prompts user for input and returns the entered string
        //
        public static string GetStringInput(string message)
        {
            Console.Write(message);
            return Console.ReadLine(); // Get and return user input
        }

        /// <summary>
        /// Prompts the user to confirm an action and returns a boolean value based on the user's input.
        /// </summary>
        /// <param name="action">A string describing the action to be confirmed.</param>
        /// <returns>True if the user confirms the action, false otherwise.</returns>
        public static bool GetConfirmation(string action)
        {
            Console.Write($"Are you sure you want to {action}? (y/n) ");
            string input = Console.ReadLine().ToLower();

            // Keep prompting until a valid input is received
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                Console.Write($"Are you sure you want to {action}? (y/n) ");
                input = Console.ReadLine().ToLower();
            }

            return input == "y";
        }
        //--------------------------------------------------------------------------------------------------------------//

    }
}



//**************************************************************END OF FILE**************************************************************//