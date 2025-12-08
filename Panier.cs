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
      Console.WriteLine($"__________________________________________");
      Console.ResetColor();
      
      //-- Variable pour stocker le total
      decimal totalPrix = 0M;

      if (panier.Count == 0) //-- Si le panier est vide
      {
        Console.WriteLine("|                                      |");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("|    * Votre panier est vide *         |"); //-- On le dit à l'utilisateur
        Console.ResetColor();
        Console.WriteLine("|                                      |\n");
      }
      else //-- Si non
      { 
        foreach (var item in panier) //-- On le parcours
        {
          Console.WriteLine($"{item.code}: {item.nom,-15} {item.prix,15}$"); //-- Et on affiche son contenu
          totalPrix += item.prix; //-- On additionne le prix de chaque articlé trouvé dans le panier
        }

        Console.WriteLine("__________________________________________");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"TOTAL: {totalPrix,28}$"); //-- Et on l'affiche
        Console.ResetColor();
      }
      Console.Write("Appuyez sur une touche pour revenir au menu...");
      Console.ReadKey();
      Console.Clear();
    }
  }
}