using System;
using System.Collections.Generic;

namespace ProjetFinal
{
  class SuppressionArticle
  {
    public static void Supprimer(List<(string code, string nom, decimal prix)> panier, string userCode, string userName)
    {
      //-- Démarre la boucle de suppression
      while (true)
      {
        Console.Write("Sélectionnez le code de l'article à supprimer ou appuyez sur 'q' pour quitter\n\n => ");
        
        string article_supprimé = Console.ReadLine();

        if (article_supprimé == "q")
        {
          //-- Retourne au menu principal
          MenuPrincipal.Menu(panier, userCode, userName);
          //-- Sort de la fonction Supprimer et met fin à la boucle
          return; 
        }

        //-- La variable booléenne ici vérifie permettra de vérifier que l'entré utilisateur correspond a un article deja dans le panier
        bool verifCode = false;

        //-- Etant donné que les index d'une listes commencent toujours à 0, on initialise notre variable à -1 pour être sûr qu'elle ne contiendra rien 
        int indexASupprimer = -1;
        for (int i = 0; i < panier.Count; i++)
        {
            if (panier[i].code == article_supprimé) //-- Si le code entré par l'utilisateur coorespond a un article existant dans le panier
            {
                indexASupprimer = i; //-- On affecte l'index correspondant a notre variable
                break; //-- Et on sort de la boucle
            }
        }

        if (indexASupprimer != -1) //-- Si l'index est différent de -1
        {
            panier.RemoveAt(indexASupprimer); //-- On le supprime
            verifCode = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✅ '{article_supprimé}' retiré du panier."); //-- Et on dit à l'utilisateur qu'il a été supprimé
            Console.ResetColor();
            
        }
        //-- Le programe continu mais comme notre booléen est encore à 'true'
        //-- cette condition est donc fausse et ne s'exécute pas, la boucle reprend pour supprimer un autre article
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