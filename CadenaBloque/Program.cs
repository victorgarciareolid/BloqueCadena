using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadenaBloque
{
    class Program
    {
        static void Main(string[] args)
        {
            Cadena c = new Cadena();
            c.addBloque("hola");
            c.addBloque("hola");
            c.addBloque("hola");
            c.addBloque("hola");
            Console.ReadKey();
        }
    }
}
