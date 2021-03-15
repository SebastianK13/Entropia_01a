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
            IO iO = new IO();
            iO.InputOutputController();
            Entropy entropy = new Entropy(iO.message);

            Console.Write("Ilość informacji dla tej wiadomości wynosi:{0}\n" +
                "Entropia warunkowa wiadomości po przekształceniu na system binarny wynosi:{1}\n" +
                "Entropia efektywna wiadomości po przekształceniu na system binarny wynosi:{2}\n" +
                "Ilość informacji dla wiadomości po przekształceniu na system binarny wynosi:{3}\n", 
                entropy.QuantityOfInformationDec, entropy.ConditionalEntropy, 
                entropy.EffectiveEntropy, entropy.QuantityOfInformation);

            Console.ReadKey();
        }
    }
}
