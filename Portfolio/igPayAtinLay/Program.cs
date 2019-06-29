using System;

namespace igPayAtinLay
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I can transate any sentence into Pig Latin. What sentence would you like me to translate?: ");
            Console.WriteLine();
            string sentence = Console.ReadLine();
            string pigLatin = ToPigLatin(sentence);
            Console.Write(pigLatin);
            Console.Read();
        }
        static string ToPigLatin(string sentence)
        {

            const string vowels = "AEIOUaeio";
            System.Collections.Generic.List<string> pigWords = new System.Collections.Generic.List<string>();

            foreach (string word in sentence.Split(' '))
            {
                string firstLetter = word.Substring(0, 1);
                string restOfWord = word.Substring(1, word.Length - 1);
                int currentLetter = vowels.IndexOf(firstLetter);
            
                if (currentLetter == -1)
                {
                    pigWords.Add(restOfWord + firstLetter + "ay");
                }

                else
                {
                    pigWords.Add(word + "yay");
                }
            }
            return string.Join(" ", pigWords);
           
        }
    }
}
