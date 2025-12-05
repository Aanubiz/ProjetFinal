using System;

namespace ProjetFinal
{
  class SuppressionArticle
  {
    public static void Supprimer(List<(string code, string nom, decimal prix)> panier, string userCode, string userName)
    {

      bool verifCode = false;

      while (true)
      {
        Console.Write("Sélectionnez un article ou appuyez sur 'q' pour quitter\n => ");
        string article_supprimé = Console.ReadLine() ?? "";
        // le nombre d'article disponible dans le panier avant la suppresion
        foreach (var item in panier)
        {
          if (article_supprimé == item.code)
          {
            panier.Remove(item);
            verifCode = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✅ '{article_supprimé}' retiré du panier.");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000); // Laisse le temps de voir le message
            break;
          }else if (article_supprimé == "q" || article_supprimé == "Q")
          {
            MenuPrincipal.Menu(panier, userCode, userName);
          }
        }

        /*---   Si l'utilisateur entre un code non valide --------*/
        if (verifCode == false)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"  ❌ Choix non valide");
          Console.ResetColor();
          System.Threading.Thread.Sleep(1000);
        }
      }
    }
  }
}