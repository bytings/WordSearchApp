using System;
using System.Collections.Generic;
using WordSearchApp;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ejecutando WordFinder...\n");

        // Definir la matriz de caracteres
        var matrix = new List<string>
        {
            "abcdc",
            "fgwio",
            "chill",
            "pqnsd",
            "uvdxy",
            "winda"
        };

        WordFinder finder = new(matrix);

        var wordstream = new List<string>
        {
            "cold", "wind", "snow", "chill"
        };

        var result = finder.Find(wordstream);

        Console.WriteLine("Palabras encontradas:");
        foreach (var word in result)
        {
            Console.WriteLine(word);
        }
    }
}
