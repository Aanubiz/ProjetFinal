using System;
using System.Collections.Generic;

namespace ProjetFinal
{
  class MenuPrincipal
  {
    
    public static void AffichageMenu() //-- Cette méthode affiche juste le menu
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
    // Cette méthode permet de traiter les opérations du menu
    public static void Menu(List<(string code, string nom, decimal prix)> panier, string userCode, string userName)
    {
      Console.Clear(); //-- Nettoie le terminal
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"\n [-- 😊 Bonjour {userName} --]\n\n"); //-- Affiche le nom d'utilisateur qui a été stocké dans la méthode authentification
      Console.ResetColor();
      AffichageMenu();


      while (true) //-- On recupère la sélection de l'utilisateur
      {
        Console.Write("________________________\n");
        Console.Write("Sélectionnez une option:\n\n => ");
        string choix_utilisateur = Console.ReadLine();

        //-- L'utilisateur devra choisir l'une des 4 options
        switch (choix_utilisateur)
        {
          //-- Lorsque l'utilisateur choisis de payer
          case "0":
            Console.Clear(); //-- On nettoie le terminal
            var verifPanier = panier.Count; //-- On stock le nombre d'article actuelement dans le panier
            if (verifPanier == 0)
            {
              Console.WriteLine("|                                      |");
              Console.ForegroundColor = ConsoleColor.Red;
              Console.WriteLine("|    * Votre panier est vide *         |"); //-- Si ce nombre est égal à 0, On ne génère pas la facture
              Console.ResetColor();
              Console.WriteLine("|                                      |\n");
              AffichageMenu();
            }
            else
            {
              Facturation.Facture(panier, userCode, userName); //-- Si le nombre est supérieur a 0, on affiche le panier
              return;
            }
            break;
            
          //-- Lorsque l'utilisateur veur voir le panier
          case "1":
            Console.Clear();
            AjoutArticle.ListeArticle(panier);
            Console.Clear();
            AffichageMenu();
            break;

          //-- L'utilisateur veux suprimer un article
          case "2":
            SuppressionArticle.Supprimer(panier, userCode, userName);
            Console.Clear();
            AffichageMenu();
            break;

          //-- L'utilisateur veux afficher le panier
          case "3":
            Console.Clear();
            Panier.Affichage(panier);
            AffichageMenu();
            break;

          //-- Si aucune option n'est choisi ou si l'utilisateur entre un caractère non reconnu
          default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ choix invalide...");
            Console.ResetColor();
            break;
        }
      }
    }
  }
}