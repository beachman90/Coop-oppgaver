using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Dynamisk path
        string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        try
        {
            // Bruker Directory.GetFiles med SearchOption.AllDirectories for å hente alle .txt filer fra alle undermapper
            string[] txtFiles = Directory.GetFiles(directoryPath, "*.txt", SearchOption.AllDirectories);

            Console.WriteLine("Sjekker .txt filer for 'sommer':");
            foreach (string file in txtFiles)
            {
                // Leser innholdet i hver fil
                string content = File.ReadAllText(file);

                // Sjekker om filene inneholder "sommer"
                if (content.Contains("sommer", StringComparison.OrdinalIgnoreCase)) // Ignorerer om det er store/små bokstaver
                {
                    Console.WriteLine($"{file} inneholder 'sommer'");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"En feil oppstod: {ex.Message}");
        }
    }
}
