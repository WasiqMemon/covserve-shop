using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_retail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SignIn()); //DONE
            Application.Run(new Intro()); //DONE
            //Application.Run(new Select_products()); //INCOMPLETE
            //Application.Run(new Cart()); //INCOMPLETE (basic functionality is working, new database error)
            // Application.Run(new SProduct());
            //Application.Run(new Account()); // INCOMPLETE (Your orders part remaining)
            //Application.Run(new Place_order()); // DONE
            // Application.Run(new SignUp()); // DONE
            
        }
    }
}
