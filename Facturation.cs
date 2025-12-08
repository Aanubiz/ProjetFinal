using System;

namespace ProjetFinal
{
  class Facturation
  {
    /// <summary>
    /// Cette procédure permet d'afficher la facture avec tout les paramètre
    /// </summary>
    /// <param name="panier"></param>
    /// <param name="userCode"></param>
    /// <param name="userName"></param>
    public static void Facture(List<(string code, string nom, decimal prix)> panier, string userCode, string userName)
    {
      //-- On déclare les taxes comme étant des constantes
      const decimal TPS = 0.05M; 
      const decimal TVQ = 0.09975M;
      const decimal pourcentageRabais = 0.25M; //-- Le pourcentage du rabais mystère (25%)

      /*-- les variables qui servent a 
      stocker le calcul des taxes*/
      decimal montantTPS;
      decimal montantTVQ;

      //-- Déclaration des autres variables
      int nombreArticle;
      decimal factureHT = 0; //-- On initialise la facture HT 
      decimal factureTotale;
      decimal rabaisAppliqué;
      
      //-- On génère un nombre aléatoire entre 0 et 1 pour appliquer ou non le rabais
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
      foreach (var item in panier)//-- On parcour le panier
      {
        Console.WriteLine($"|     ≫ {item.nom,-30}{item.prix,1}$"); //-- Et affiche son contenu
        factureHT += item.prix; //-- On calcul les prix des articles qui y figures
      }
      //-- On compte le nombre d'article dans le panier
      nombreArticle = panier.Count;
      
      //-- On défini la date selon le format
      DateTime date = DateTime.Today;
      string dateSeule = date.ToString("d");

      //-- On défini l'heure selon le format
      DateTime heure = DateTime.Now;
      string heureSeule = heure.ToString("T");

      Console.WriteLine("|                                                   |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|     -------------------------------------         |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine($"|      Nombre d'articles:         {nombreArticle,1} "); //-- On affiche le nombre d'article figurant dans le panier
      Console.WriteLine("|                                                   |");

      //-- On calcule la valeur des taxes pour le prix total des article et garde 2 chiffres après la virgule
      montantTPS = Math.Round(factureHT * TPS, 2, MidpointRounding.AwayFromZero);
      montantTVQ = Math.Round(factureHT * TVQ, 2, MidpointRounding.AwayFromZero);

      if (chanceRabaisMystère == 1) //-- Si le Random génère '1' durant l'exécusion
      {
        //-- On applique le rabai qui est le porcentage multiplié par le total de la facture
        rabaisAppliqué = Math.Round(factureHT * pourcentageRabais, 2, MidpointRounding.AwayFromZero); 
        
        //-- On Calcule le nouveau prix a afficher à l'utilisateur en tenant compte du rabais
        factureHT = Math.Round(factureHT - rabaisAppliqué, 2, MidpointRounding.AwayFromZero);
        
        //-- On applique les taxes sur le nouveau prix
        factureTotale = Math.Round(factureHT + TPS + TVQ * TVQ, 2, MidpointRounding.AwayFromZero);

        Console.WriteLine($"|      Rabais mystère         {rabaisAppliqué}  "); //-- On affiche le rabais qui a été appliqué
        Console.WriteLine("|     -------------------------------------  |\n ");
        Console.WriteLine($"|      Total hors taxe:       {factureHT} ");      //-- On affiche le prix après soustraction du rabais
        Console.WriteLine($"|      TPS:                   {montantTPS}             "); //-- On applique la TPS qui a été calculé sur la facture HT
        Console.WriteLine($"|      TVQ:                   {montantTVQ}             ");//-- Pareil pour la TVQ
        Console.WriteLine($"|      TOTAL                  {factureTotale}   ");      //-- On affiche la facture avec rabais et taxes
      }
      else //-- Si le Randon génère plutôt 0
      {
        //-- Aucun rabais n'est appliqué et factureHT correspondra au total initial des prix des articles
        //-- additionné aux taxes
        factureTotale = Math.Round(factureHT + TPS + TVQ, 2, MidpointRounding.AwayFromZero);

        Console.WriteLine($"|      Total hors taxe:       {factureHT}       ");
        Console.WriteLine($"|      TPS:                   {montantTPS}             ");
        Console.WriteLine($"|      TVQ:                   {montantTVQ}             ");
        Console.WriteLine($"|      TOTAL                  {factureTotale}   ");
      }
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|     ************************************          |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine($"|     Vous avez été servi par:       {userName}     "); //-- On affiche le nom de l'employé sur la facture
      Console.WriteLine($"|     Caisse N°:                     {userCode}     "); //-- Ainsi que le numéro de la caisse
      Console.WriteLine($"|     Méthode de payement:                         |");
      Console.WriteLine($"|     Date:                         {dateSeule}     "); //-- La date
      Console.WriteLine($"|     Heure:                        {heureSeule}    "); //-- et l'heure du jour
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|     ************************************          |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|      MERCI DE VOTRE VISITE! A BIENTÔT...          |");
      Console.WriteLine("|                                                   |");
      Console.WriteLine("|___________________________________________________|");

    }
  }
}