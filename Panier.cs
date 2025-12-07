using System;
using System.Collections.Generic;


namespace ProjetFinal
{
  class Panier
  {
    
    public static void Affichage(List<(string code, string nom, decimal prix)> panier)
    {
      Console.Clear();
      
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine($"__________________________________________");
      Console.WriteLine($"               Votre Panier               ");
      Console.WriteLine($"__________________________________________\n");
      Console.ResetColor();
      
      // Variable pour stocker le total
      decimal totalPrix = 0M;

      if (panier.Count == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("      Le panier est vide.");
        Console.ResetColor();
      }
      else
      { 
        foreach (var item in panier)
        {
          // Affichage détaillé selon votre demande : Code: Nom - Prix
          Console.WriteLine($"{item.code}: {item.nom,-15} {item.prix,15}$");
          // Additionner le prix de l'article au total
          totalPrix += item.prix;
        }

        Console.WriteLine("__________________________________________");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"TOTAL: {totalPrix,28}$");
        Console.ResetColor();
      }
      Console.Write("Appuyez sur n'importe quelle touche pour revenir au menu...\n\n");
      Console.ReadKey();
      Console.Clear();
    }
  }
}