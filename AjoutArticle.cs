using System;

namespace ProjetFinal
{
  class AjoutArticle
  { /*------ Cette méthode gère l'ajout des nouveaux articles ------*/
    public static void ListeArticle(List<(string code, string nom, decimal prix)> panier)
    {
      
      /*--------- Déclaration de la liste des articles --------------*/
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
      
      foreach (var item in articles)
      {
        Console.WriteLine($"{item.code}: {item.nom,-15} - {item.prix,15}\n");
      }

      /*---------- On recupère les sélections de l'utilisateur -----------*/
      while (true)
      {
        Console.WriteLine("\n_______________________________________________");
        Console.WriteLine("Sélectionnez un article ou tapez 'q' pour quitter");
        var codeEntré = Console.ReadLine();
        bool verifCode = false;

        foreach (var item in articles)
        {
          if (codeEntré == item.code)
          {
            panier.Add(item);
            /*Cette ligne permet d'ajouté l'élément sélectionné dans la 
            liste articleAjouté qui se trouve dans le fichier Panier.cs*/
            verifCode = true; //On affecte la valeur vrai au code de vérification
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✅ '{item.nom}' ajouté au panier.");
            Console.ResetColor();
            break;
          }
        }
        //Peu importe si l'utilisateur écris 'q' ou 'Q'
        if (codeEntré == "q" || codeEntré == "Q")
        {
          //si l'utilisateur entre 'q' on sort de la boucle
          break; 
        }
        
        if (verifCode == false)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"  ❌ Choix non valide");
          Console.ResetColor();
        }  
      }
    }
  }
}