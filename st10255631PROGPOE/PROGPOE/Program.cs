//**************************************************************START OF IMPORTS**************************************************************//

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
//             Bro Code (2022). C# Full Course for free 🎮. [online] Available at: https://www.youtube.com/watch?v=wxznTygnRfQ&list=WL&index=1.

// GITHUB LINK: https://github.com/Joshua-shields/st10255631PROGPOE.git

namespace RecipeManager
{
    internal class Program
    {
        /// <summary>
        /// The main method the entry point of the program.
        /// This method is executed when the program is run.
        /// It creates an instance of the RecipeCollection class and calls its Menu method.
        /// </summary>
        static void Main(string[] args)
        {
            RecipeCollection manager = new RecipeCollection();
            manager.Menu();
        }
    }
}
//**************************************************************END OF FILE**************************************************************//