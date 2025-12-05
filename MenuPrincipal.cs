using System;
using System.Collections.Generic;

namespace ProjetFinal
{
  class MenuPrincipal
  {
    public static void AffichageMenu()
    {
      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine("__________________________________________");
      Console.WriteLine("             MENU PRINCIPAL               ");
      Console.WriteLine("__________________________________________");
      Console.ResetColor();
      Console.WriteLine("1. Ajouter un article\n");
      Console.WriteLine("2. Supprimer un Article\n");
      Console.WriteLine("3. Afficher le Panier\n");
      Console.WriteLine("0. Payer");
    }
    // La signature est mise à jour pour utiliser la liste d'articles complète
    public static void Menu(List<(string code, string nom, decimal prix)> panier, string userCode, string userName)
    {

      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"\n [-- 😊 Bonjour {userName} --]\n\n");
      Console.ResetColor();
      AffichageMenu();


      while (true) // Boucle infinie, sortie par 'break' ou 'return'
      {

        Console.Write("________________________\n");
        Console.Write("Sélectionne une option:\n => ");
        string choix_utilisateur = Console.ReadLine() ?? "";

        // switch
        switch (choix_utilisateur)
        {
          // quand l'utilisateur choisi ajouter article
          case "0":
            Console.Clear();
            var test = panier.Count;
            if (test == 0)
            {
              Console.WriteLine("❌ Votre panier est vide...");
              AffichageMenu();
            }
            else
            {
              Facturation.Facture(panier, userCode, userName);
            }
           break;

         

          case "1":
            Console.Clear();
            AjoutArticle.ListeArticle(panier);
            Console.Clear();
            AffichageMenu();
            break;

          // quand l'utilisateur choisi le panier
          case "2":
            SuppressionArticle.Supprimer(panier, userCode, userName);
            Console.Clear();
            AffichageMenu();
            break;

          case "3":
            Console.Clear();
            Panier.Affichage(panier);
            AffichageMenu();
            break;

          default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ choix invalide...");
            Console.ResetColor();
            // Petite pause et nettoyage pour afficher les options à nouveau
            System.Threading.Thread.Sleep(500);
            Console.Clear();
            AffichageMenu();
            break;
        }
      }
    }
  }
}