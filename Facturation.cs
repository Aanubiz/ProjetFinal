using System;

namespace ProjetFinal
{
  class Facturation
  {
    public static void Facture(List<(string code, string nom, decimal prix)> panier, string employe)
    {
      // declaration des variables
      double sous_total = 0;

      Console.WriteLine("       Sous-total:    " + sous_total + "$");
      // declaration de variable TPS (taxe des produit et service)
      double TPS = 0.05;
      TPS = TPS * sous_total;

      // arrontir le TPS
      double TPS_arrondi = Math.Round(TPS, 2);

      // affichage
      Console.WriteLine("              TPS:     " + TPS_arrondi + "$");

      // declaration de la variable TVQ (taxe des ventes et service)
      double TVQ = 0.09975;
      TVQ = TVQ * sous_total;

      // arrondir le  TVQ 
      double TVQ_arrondi = Math.Round(TVQ, 2);

      // affichage du TVQ
      Console.WriteLine("              TVQ:     " + TVQ_arrondi + "$");

      // calcul de la somme des taxe 
      double somme_taxe;
      somme_taxe = TPS_arrondi + TVQ_arrondi;

      // calcul du total
      double total;
      total = sous_total + somme_taxe;

      // affichage du total
      Console.WriteLine("            Total:    " + total + "$");
      Console.WriteLine("***************************");

      // afficher le nom de l'employe qui a servi
      Console.WriteLine("Vous avez été servi par " + employe);
      Console.WriteLine("");

      // afficher la date
      string date = DateTime.Now.ToString("dd/MM/yyyy");

      Console.WriteLine("Date : " + date);
      Console.WriteLine("");

      // afficher l'heure
      string heure = DateTime.Now.ToString("HH:mm:ss");
      Console.WriteLine("Heure : " + heure);
      Console.WriteLine("");
      Console.WriteLine("***************************");


    }
  }
}