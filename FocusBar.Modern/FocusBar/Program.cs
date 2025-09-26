using System;
using Eto.Forms;

namespace FocusBar
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // Create Eto application with automatic platform detection
            var app = new Application();
            
            // Create and run the focus bar form
            var form = new FocusBarForm();
            app.Run(form);
        }
    }
}
