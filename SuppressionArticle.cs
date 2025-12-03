using System;

namespace ProjetFinal
{
  class SuppressionArticle
  {
     public static void Supprimer(List<(string code, string nom, decimal prix)> panier)
    {
      // declaration des variables
      string utilisateu_supprimer = "";
      
      Console.Write("");

      while (true)
      {

        Console.Write("Sélectionnez un article ou appuyez sur 'q' pour quitter\n => ");
        utilisateu_supprimer = Console.ReadLine() ?? "";
        // le nombre d'article disponible dans le panier avant la suppresion
        int avant = panier.Count;
        panier.RemoveAll(item => item.code == utilisateu_supprimer);

        // le nombre d'article disponible dans le panier apres la suppresion
        int apres = panier.Count;

        if (avant == apres)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write("Choix non disponible");
          Console.ResetColor();

        }

        else
        {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine($"\n ✅ Article Supprimé\n\n"); //Si la boucle a trouvé l'Id
          Console.ResetColor();
          break;

        }
      }
  }
  }
}