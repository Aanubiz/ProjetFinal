using System;

namespace ProjetFinal
{
  class AjoutArticle
  { /*-- Cette méthode gère l'ajout des nouveaux articles --*/
    public static void ListeArticle(List<(string code, string nom, decimal prix)> panier)
    {
      
      /*-- Déclaration de la liste des articles --*/
      List<(string code, string nom, decimal prix)> articles = new ();
      articles.Add(("A1", "Crayon", 3.99M));
      articles.Add(("A2", "Cahier Canada", 1.59M));
      articles.Add(("B1", "Table Pliante", 66.99M));
      articles.Add(("B2", "Fauteuil en cuir", 199.99M));
      articles.Add(("B3", "Bureau d'étudiant", 118.99M));
      articles.Add(("L1", "Laptop ASUS", 600.89M));
      articles.Add(("L2", "Laptop HP", 700.89M));
      articles.Add(("L3", "Laptop ACER", 250.99M));

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.WriteLine($"________________________________________________");
      Console.WriteLine($"                  AJOUT ARTICLE                     ");
      Console.WriteLine($"________________________________________________\n\n");
      Console.ResetColor();
      
      //-- On parcour le tableau pour afficher son contenu
      foreach (var item in articles)
      {
        Console.WriteLine($"{item.code}: {item.nom,-15} - {item.prix,15}\n");
      }

      /*-- On recupère les sélections de l'utilisateur --*/
      while (true)
      {
        Console.WriteLine("\n_______________________________________________");
        Console.Write("Sélectionnez un article ou tapez 'q' pour quitter\n\n => ");
        string codeEntré = Console.ReadLine();
        
        //-- On déclare une variable booléenne qui permettra de 
        //-- vérifier si le code entré par l'utilisateur est correcte
        bool verifCode = false; 
        //-- Cette boucle parcours le panier et recupère l'article correspondant a l'entrée utilisateur
        foreach (var item in articles)
        {
          if (codeEntré == item.code) //-- Le code entré par l'utilisateur correspond a un article ficgurant dans le panier
          {
            panier.Add(item); //-- On ajoute cet article au panier
            verifCode = true; //-- Notre code de vérification devient vrai
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✅ '{item.nom}' ajouté au panier."); //-- Et on informe l'utilisateur que l'article qu'il a sélectionné a été correctement ajouté au panier
            Console.ResetColor();
            break;
          }
        }
        
        if (codeEntré == "q" || codeEntré == "Q")
        {
          //-- Lorsque l'utilisateur choisi de quitter l'écran d'ajout, la boucle s'arrête et le programme revien au menu
          break; 
        }
        
        if (verifCode == false)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"  ❌ Choix non valide"); //-- Si l'entré utilisateur ne correspond a aucun article figurant dans le panier
          Console.ResetColor();
        }  
      }
    }
  }
}