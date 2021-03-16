using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entropia_01a
{
    public class IO
    {
        private Language language;
        public Message message = new Message();
        public IO()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            language = new Language();
            language.CreateLanguageList();
        }
        public void InputOutputController()
        {
            GetMessage();
            GetChoosenLanguage();
        }
        //Pobranie wiadomości od użytkownika
        private void GetMessage() 
        {
            Console.WriteLine("Wprowadź tekst(tylko litery): ");
            string input="";
            bool result = false;
            do
            {
                input = Console.ReadLine();

                if(input != "")
                    result = ContainsLettersOnly(input);

                if (!result)
                    Console.WriteLine("Błąd, wprowadzona wartość nie spełnia powyższych wymagań: ");

            } while (!result);

            message.MessageContent = input;
            message.MessageLength = input.Length;
        }
        //Wybór języka
        private void GetChoosenLanguage()
        {
            Console.Write("1.Alfabet polski\n2.Alfabet angielski" +
                "\n3.Alfabet niemiecki\n4.Alfabet francuski\n5.Alfabet czeski\n");
            Console.WriteLine("Wprowadź cyfrę z zakresu [1,5] aby wybrać odpowiedni alfabet:");
            string digit;
            bool result = false;
            do
            {
                digit = Console.ReadLine();
                if(digit.Length < 2 && digit != "")
                {
                    result = IsDigitFromRange(digit);
                }
                
                if(!result)
                    Console.WriteLine("Błąd, wprowadzona wartość nie spełnia powyższych wymagań: ");

            } while (!result);

            Console.WriteLine("Entropia alfabetu {0} wynosi {1}", message.Language.Name, message.Language.EntropyValue);
        }
        //Sprawdzenie czy wiadomość zawiera tylko litery
        private bool ContainsLettersOnly(string message)
        {
            foreach(char c in message)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
        //Sprawdzenie czy wprowadzona wartość jest cyfrą i czy mieści się w podanym zakresie
        private bool IsDigitFromRange(string insertedNum)
        {
            foreach (char c in insertedNum)
            {
                if (!Char.IsDigit(c))
                    return false;
            }

            int digit = Convert.ToInt32(insertedNum);

            if (digit < 1 || digit > 5)
            {
                return false;
            }
            else
            {
                message.Language = language.GetAlphabetEntropy(digit);
                return true;
            }
        }
    }
    public class Language
    {
        public string Name { get; set; }
        public double EntropyValue { get; set; }
        private List<Language> languages;
        public void CreateLanguageList() =>
            languages = new List<Language>
            {
                new Language {Name = "Polish", EntropyValue = Math.Round((Math.Log(32) / Math.Log(2)), 2,
                                             MidpointRounding.ToEven)},
                new Language {Name = "English", EntropyValue = Math.Round((Math.Log(26) / Math.Log(2)), 2,
                                             MidpointRounding.ToEven)},
                new Language {Name = "German", EntropyValue = Math.Round((Math.Log(30) / Math.Log(2)), 2,
                                             MidpointRounding.ToEven)},
                new Language {Name = "French", EntropyValue = Math.Round((Math.Log(31) / Math.Log(2)), 2,
                                             MidpointRounding.ToEven)},
                new Language {Name = "Czech", EntropyValue = Math.Round((Math.Log(37) / Math.Log(2)), 2,
                                             MidpointRounding.ToEven)}
            };
        public Language GetAlphabetEntropy(int digit) => 
            languages[digit - 1];

    }
    public class Message
    {
        public int MessageLength { get; set; }
        public Language Language { get; set; }
        public string MessageContent { get; set; }
        //Prawdopodobieństwo wystąpienia błędu
        public double ErrorProb = 0.01;
    }
}
