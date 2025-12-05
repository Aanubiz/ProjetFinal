using System;
using System.Collections.Generic;

namespace ProjetFinal
{
  class SuppressionArticle
  {
    public static void Supprimer(List<(string code, string nom, decimal prix)> panier, string userCode, string userName)
    {
      // Démarre la boucle de suppression
      while (true)
      {
        Console.Write("Sélectionnez le code de l'article à supprimer ou appuyez sur 'q' pour quitter\n\n => ");
        // Utilisation du string? pour gérer la nullité potentielle de Console.ReadLine()
        string article_supprimé = Console.ReadLine();

        if (article_supprimé == "q")
        {
          // Retourne au menu principal
          MenuPrincipal.Menu(panier, userCode, userName);
          // Sort de la fonction Supprimer et met fin à la boucle infinie
          return; 
        }

        // Reset du drapeau de vérification pour cette tentative de suppression
        bool verifCode = false;

        // 2. Recherche et suppression de l'article
        // IMPORTANT : Pour éviter l'erreur de modification de la collection lors de l'itération,
        // nous utilisons une boucle for inversée ou nous sortons immédiatement après Remove.
        // Pour respecter votre structure de foreach, nous allons chercher l'index et sortir.

        // Trouver l'index de l'article pour une suppression sûre
        int indexASupprimer = -1;
        for (int i = 0; i < panier.Count; i++)
        {
            if (panier[i].code == article_supprimé)
            {
                indexASupprimer = i;
                break; // Article trouvé, on sort de la boucle de recherche
            }
        }

        if (indexASupprimer != -1)
        {
            // Suppression de l'élément à l'index trouvé
            panier.RemoveAt(indexASupprimer);
            verifCode = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✅ '{article_supprimé}' retiré du panier.");
            Console.ResetColor();
            
            // L'article a été trouvé et supprimé. On sort de la boucle while pour revenir à la saisie.
            // La boucle while recommence pour demander la prochaine action.
        }

        /*---   Si l'utilisateur entre un code non valide --------*/
        if (verifCode == false)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"  ❌ Cet article n'est pas dans votre panier.");
          Console.ResetColor();
        }
      }
    }
  }
}