using System;
using System.IO;
using System.Text.Json;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Angi stien til JSON-filen
        string filePath = @"array.json";

        try
        {
            // Les JSON-innholdet fra filen
            string jsonString = File.ReadAllText(filePath);

            // Deserialiser JSON-strengen til et int-array, og legger inn default verdi for å unngå possible null
            int[] numbers = JsonSerializer.Deserialize<int[]>(jsonString) ?? new int[0];

            // Filtrer ut oddetall og behold kun partall
            int[] evenNumbers = numbers.Where(n => n % 2 == 0).ToArray();

            // Beregn summen av alle partall
            int sumOfEvenNumbers = evenNumbers.Sum();

            // Skriver ut summen av alle partall
            Console.WriteLine("Partall:");
            foreach (int num in evenNumbers)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine($"\nSummen av alle partall: {sumOfEvenNumbers}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"En feil oppstod: {ex.Message}");
        }
    }
}
