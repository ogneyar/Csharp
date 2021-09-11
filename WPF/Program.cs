using System;
using System.Windows;

namespace HelloWpf
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new TestWindow());
        }
    }
}