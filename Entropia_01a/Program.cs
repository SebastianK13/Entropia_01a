using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropia_01a
{
    class Program
    {
        static void Main(string[] args)
        {
            IO controller = new IO();
            controller.InputOutputController();
            
            Console.ReadKey();
        }
    }
}
