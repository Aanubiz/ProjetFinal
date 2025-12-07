using System;

namespace ProjetFinal
{
  class Facturation
  {
    public static void Facture(List<(string code, string nom, decimal prix)> panier, string userCode, string userName)
    {
      const decimal TPS = 0.05M;
      const decimal TVQ = 0.09975M;
      const decimal pourcentageRabais = 0.25M;

      decimal montantTPS;
      decimal montantTVQ;

      int nombreArticle;
      decimal factureHT = 0;
      decimal factureTotale = 0;
      decimal rabaisAppliqué = 0;
      Random random = new Random();
      int chanceRabaisMystère = random.Next(0, 2);

      Console.WriteLine("_____________________________________________________");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|          ****** F A C T U R E ******              |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|   PRODUITS                                        |");
      Console.WriteLine("|                                                   |");
      foreach (var item in panier)
      {
        Console.WriteLine($"|     ≫ {item.nom,-30}{item.prix,1}$");
        factureHT += item.prix;
      }
      //On compte le nombre d'article dans le panier
      nombreArticle = panier.Count;
      /*-- On défini la date selon le format --*/
      DateTime date = DateTime.Today;
      string dateSeule = date.ToString("d");

      /*-- On défini l'heure selon le format --*/
      DateTime heure = DateTime.Now;
      string heureSeule = heure.ToString("T");

      Console.WriteLine("|                                                   |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|     -------------------------------------         |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine($"|      Nombre d'articles:         {nombreArticle,1} ");
      Console.WriteLine("|                                                   |");
      decimal facturerabaissé = factureHT;

      montantTPS = Math.Round(facturerabaissé * TPS, 2, MidpointRounding.AwayFromZero);
      montantTVQ = Math.Round(facturerabaissé * TVQ, 2, MidpointRounding.AwayFromZero);

      if (chanceRabaisMystère == 1)
      {

        rabaisAppliqué = Math.Round(factureHT * pourcentageRabais, 2, MidpointRounding.AwayFromZero);
        facturerabaissé = Math.Round(factureHT - rabaisAppliqué, 2, MidpointRounding.AwayFromZero);
        factureTotale = Math.Round(facturerabaissé + TPS + TVQ * TVQ, 2, MidpointRounding.AwayFromZero);

        Console.WriteLine($"|      Rabais mystère         {rabaisAppliqué}  ");
        Console.WriteLine("|     -------------------------------------  |\n ");
        Console.WriteLine($"|      Total hors taxe:       {facturerabaissé} ");
        Console.WriteLine($"|      TPS:                   {montantTPS}             ");
        Console.WriteLine($"|      TVQ:                   {montantTVQ}             ");
        Console.WriteLine($"|      TOTAL                  {factureTotale}   ");
      }
      else
      {
        factureTotale = Math.Round(factureHT + TPS + TVQ, 2, MidpointRounding.AwayFromZero);

        Console.WriteLine($"|      Total hors taxe:       {factureHT}       ");
        Console.WriteLine($"|      TPS:                   {montantTPS}             ");
        Console.WriteLine($"|      TVQ:                   {montantTVQ}             ");
        Console.WriteLine($"|      TOTAL                  {factureTotale}   ");
      }
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|     ************************************          |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine($"|     Vous avez été servi par:       {userName}     ");
      Console.WriteLine($"|     Caisse N°:                     {userCode}     ");
      Console.WriteLine($"|     Méthode de payement:                         |");
      Console.WriteLine($"|     Date:                         {dateSeule}     ");
      Console.WriteLine($"|     Heure:                        {heureSeule}    ");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|     ************************************          |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|             MERCI POUR VOTRE VISITE               |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|___________________________________________________|");

    }
  }
}