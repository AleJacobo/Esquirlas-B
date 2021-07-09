using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esquirlas.Domain.Entities
{
    public class Personaje
    {
        public Guid PersonajeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
        public string Status { get; set; }
        public bool IsDeleted { get; set; }

        //para heredar de la otra clase
        public virtual Faccion Faccion { get; set; }

        //para heredar los enums y diccionaries
        public virtual Casa Casa { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public virtual Clase Clase { get; set; }
        public virtual Deidad Deidad { get; set; }

        // formulas para guid
        /*
        1.
        Guid.NewGuid();
        
        2. 
        class RandomStringGenerator
        {
            public const string ALPHANUMERIC_CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            public const string ALPHA_CAPS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            public const string NUMERIC = "1234567890";

            Random Rand = new Random();
            public string GetRandomString(int length, params char[] chars)
            {
                string s = "";
                for (int i = 0; i < length; i++)
                    s += chars[Rand.Next() % chars.Length];

                return s;
            }
        }

        3. 
        Guid g = Guid.NewGuid();
        Console.WriteLine(g);
        Console.WriteLine(Guid.NewGuid());

        4.
        string cadenaAleatoria = string.Empty;
        cadenaAleatoria = Guid.NewGuid().ToString();

        5.
        RandomStringGenerator stringGen = new RandomStringGenerator();
        string id = stringGen.GetRandomString(20, RandomStringGenerator.ALPHANUMERIC_CAPS.ToCharArray());
        */
    }
}
