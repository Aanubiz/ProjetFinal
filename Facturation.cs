using System;

namespace ProjetFinal
{
  class Facturation
  {
    public static void Facture(List<(string code, string nom, decimal prix)> panier, string userCode, string userName)
    {
      int nombreArticle;
      decimal factureTotale = 0;
      const decimal TPS = 22.53M;
      const decimal TVQ = 44.95M;
      
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
        Console.WriteLine($"|     *{item.nom,-30}{item.prix,1}$");
        factureTotale += item.prix;
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
      Console.WriteLine($"|       Rabais mystère                 {0}          ");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|     -------------------------------------         |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine($"|      Nombre d'articles:          {nombreArticle,1}");
      Console.WriteLine("|                                                   |");
      Console.WriteLine($"|      Total hors taxe:            {factureTotale,1}");
      Console.WriteLine($"|      TPS:                            {TPS,1}      ");
      Console.WriteLine($"|      TVQ:                            {TVQ,1}      ");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine($"|      TOTAL           {factureTotale + TPS + TVQ,1}");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|      Le système applique automatiquement          |");
      Console.WriteLine("|        et de façon aléatoire un rabais            |");
      Console.WriteLine("|         mystère aux facture éligible.             |");
      Console.WriteLine("|              Bonne chance!!!                      |");
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