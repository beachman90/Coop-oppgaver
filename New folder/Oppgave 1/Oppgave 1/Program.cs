using System;
using System.IO;

namespace Oppgave_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = "file.txt"; // Bruker relativ sti for enkelhet

            // Sjekker om filen eksisterer
            if (File.Exists(filePath))
            {
                // Leser hver linje i filen
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    // Reverserer strengen
                    string reversedLine = ReverseString(line);
                    Console.WriteLine(reversedLine);
                }
            }
            else
            {
                Console.WriteLine($"Filen '{filePath}' ble ikke funnet.");
            }
        }

        // Hjelpemetode for å reversere strengen
        static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
