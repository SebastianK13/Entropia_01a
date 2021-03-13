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
        private Message message = new Message();
        public IO()
        {
            language = new Language();
            language.CreateLanguageList();
        }
        public void InputOutputController()
        {
            GetMessage();
            GetChoosenLanguage();
        }
        private void GetMessage() 
        {
            Console.WriteLine("Wprowadź tekst(tylko litery): ");
            string input;
            bool result = false;
            do
            {
                input = Console.ReadLine();
                result = ContainsLettersOnly(input);
                if (!result)
                    Console.WriteLine("Błąd, wprowadzony wartość nie spełnia powyższych wymagań: ");

            } while (!result);

            message.MessageContent = input;
            message.MessageLength = input.Length;
        }
        private void GetChoosenLanguage()
        {
            Console.Write("1.Alfabet polski\n2.Alfabet angielski" +
                "\n3.Alfabet niemiecki\n4.Alfabet francuski\n5.Alfabet Czeski\n");
            Console.WriteLine("Wprowadź cyfrę z zakresu [1,5] aby wybrać odpowiedni alfabet:");
            string digit;
            bool result = false;
            do
            {
                digit = Console.ReadLine();
                if(digit.Length < 2)
                {
                    result = IsDigitFromRange(digit);
                }
                
                if(!result)
                    Console.WriteLine("Błąd, wprowadzony wartość nie spełnia powyższych wymagań: ");

            } while (!result);

        }
        private bool ContainsLettersOnly(string message)
        {
            foreach(char c in message)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
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
                new Language {Name = "Polish", EntropyValue = 5},
                new Language {Name = "English", EntropyValue = 4.7},
                new Language {Name = "German", EntropyValue = 4.75},
                new Language {Name = "French", EntropyValue = 4.95},
                new Language {Name = "Czech", EntropyValue = 5.21}
            };
        public Language GetAlphabetEntropy(int digit) => 
            languages[digit - 1];

    }
    public class Message
    {
        public int MessageLength { get; set; }
        public Language Language { get; set; }
        public string MessageContent { get; set; }
    }
}
