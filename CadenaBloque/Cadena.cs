using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadenaBloque
{
    class Cadena
    {
        public Cadena()
        {
            Bloque aux = Bloque.genesisBloque();
            cadena.Add(aux);
        }

        public void addBloque(string data)
        {
            Bloque b = new Bloque(numBloques, data, cadena.Last().getHash());
            b.mine();
            cadena.Add(b);
            numBloques++;
            Console.WriteLine("Se ha incluido el bloque:\n{0}", b.toString());
        }

        private int numBloques = 1;
        private List<Bloque> cadena = new List<Bloque>();
    }
}
