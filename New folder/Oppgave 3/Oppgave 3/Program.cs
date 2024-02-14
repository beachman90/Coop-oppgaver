using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Dynamisk path
        string directoryPath = AppDomain.CurrentDomain.BaseDirectory;
        int count = 0; // Teller for å holde styr på antall .txt filer som inneholder "sommer"

        try
        {
            // Bruker Directory.GetFiles med SearchOption.AllDirectories for å hente alle filer fra alle undermapper
            string[] allFiles = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

            Console.WriteLine("Liste over alle filer:");
            foreach (string file in allFiles)
            {
                // Skriver ut alle filene
                Console.WriteLine(Path.GetFileName(file));

                // Sjekker kun .txt filer for "sommer"
                if (Path.GetExtension(file).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                {
                    string content = File.ReadAllText(file);
                    if (content.Contains("sommer", StringComparison.OrdinalIgnoreCase))
                    {
                        count++; // Øker telleren for hver .txt fil som inneholder "sommer"
                    }
                }
            }

            // Skriver ut totalt antall .txt filer som inneholder "sommer"
            Console.WriteLine($"\nTotalt antall .txt filer som inneholder 'sommer': {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"En feil oppstod: {ex.Message}");
        }
    }
}
