using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CadenaBloque
{
    class Bloque
    {
        private int id, nonce=0;
        private string data, previousHash, Hash;
        DateTime timestamp;

        public Bloque(int id, string data, string previousHash)
        {
            this.id = id;
            this.previousHash = previousHash;
            this.data = data;
            timestamp = DateTime.Now;
        }

        public string toString()
        {
            return String.Format("Id: {0}\nData:\n{1}\nNonce: {2}\nPreviousHash: {3}\nTimestamp: {4}\nHash: {5}\n", id, data, nonce, previousHash, timestamp, Hash);
        }

        public void mine()
        {
            string Hashs = id.ToString() + previousHash.ToString() + timestamp.ToString();
            
            StringBuilder sb = new StringBuilder();
            byte[] Hashb;
            using (SHA256 s = SHA256.Create())
            {
                Hashb = s.ComputeHash(Encoding.UTF8.GetBytes(Hashs + nonce));

                while (Hashb[0].ToString() != "0")
                {
                    Hashb = s.ComputeHash(Hashb);
                    nonce++;
                }
            }

            for(int i=0; i<Hashb.Count(); i++)
            {
                sb.Append(Hashb[i]);
            }
            Hash = sb.ToString();
        }

        public static Bloque genesisBloque()
        {
            Bloque aux = new Bloque(0, "", "");
            aux.mine();
            return aux;
        }

        public string getHash()
        {
            return Hash;
        }
    }
}
