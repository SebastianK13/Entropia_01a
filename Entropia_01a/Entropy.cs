using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropia_01a
{
    public class Entropy
    {
        private readonly Message _message;
        private string binaryMessage;
        private readonly double BinaryAEntropy;
        public double ConditionalEntropy { get; set; }
        public double EffectiveEntropy { get; set; }
        public double QuantityOfInformation { get; set; }
        public double QuantityOfInformationDec { get; set; }
        public Entropy(Message message)
        {
            _message = message;
            QuantityOfUnconvertedMsg();
            ToBinary();
            BinaryAEntropy =  CountBinaryAlphabetEntropy();
            SetConditionalEntropy();
            SetEffectiveEntropy();
            SetQsOfInformation();
        }
        //Konwersja wiadomości użytkownika na system binarny
        private void ToBinary()
        {
            int n = _message.MessageLength;

            for (int i = 0; i < n; i++)
            {
                int val = _message.MessageContent[i];

                string binaryCode = "";
                while (val > 0)
                {
                    if (val % 2 == 1)
                    {
                        binaryCode += '1';
                    }
                    else
                        binaryCode += '0';
                    val /= 2;
                }
                binaryMessage += new string(binaryCode.Reverse().ToArray())+" ";
            }
        }
        //Obliczanie entropii alfabetu binarnego
        private double CountBinaryAlphabetEntropy() =>
            Math.Round((Math.Log(2) / Math.Log(2)), 2,
            MidpointRounding.ToEven);
    
        //Obliczanie entropii warunkowej
        private void SetConditionalEntropy()
        {
            double value = -1 + _message.ErrorProb;
            var t = ((-_message.ErrorProb * Math.Log(_message.ErrorProb)) / Math.Log(2));
            var t2 = ((value * Math.Log(-value)) / Math.Log(2));

            ConditionalEntropy = Math.Round(t + t2, 3, MidpointRounding.ToEven);
        }
        //Obliczanie entropii efektywnej
        private void SetEffectiveEntropy() =>
            EffectiveEntropy = 1 - ConditionalEntropy;

        //Obliczanie ilości informacji
        private void SetQsOfInformation()
        {
            int temp = binaryMessage.Length;
            int amountOfCharacters = binaryMessage.Replace(" ","").Length;

            QuantityOfInformation = amountOfCharacters * EffectiveEntropy;
        }
        //Obliczanie ilości informacji dla  wiadomości przed zamianą na system binarny
        private void QuantityOfUnconvertedMsg() =>
            QuantityOfInformationDec = _message.MessageLength * _message.Language.EntropyValue;
    }
}
