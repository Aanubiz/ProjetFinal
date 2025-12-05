using System;
using System.Collections.Generic; 

namespace ProjetFinal
{
  class Authentification
  {
    
     /*-- Cette méthode gère la connexion de l'employé et lance le menu --*/
    public static void CodeUtilisateur(List<(string code, string nom, decimal prix)> panier)
    {
      /*-- Déclaration de variable --*/

      string [] id = {"001", "002", "003","004","005"}; //Tableau des identifiants
      string [] noms = {"sammir", "Mohamed","Afef","Jean-Gabriel","Eve"}; //Tableau des noms

      bool idCorrect = false; //Vérifier si l'utilisateur entre une id correct
      string userName = ""; //Stocker le nom correspondant à l'entrée de utilisateur
      string userCode = ""; //Stocker le nom correspondant à l'entrée de utilisateur
      
      while (!idCorrect) //Si idCorrect == false, la condition est vrai donc la boucle continue
      {
        //Console.Clear();
        Console.WriteLine("_________________________________");
        Console.Write("Veuillez saisir votre identifiant\n => ");
         
        var idEntré = Console.ReadLine(); //Entrée utilisateur
        for (int i = 0; i < id.Length; i++)
        {
          //On compare l'id entrée avec ceux qui existent dans le tableau
          if (id[i] == idEntré)
          {
            userName = noms[i]; //On récupère le nom correspondant
            userCode = id[i]; //On récupère le nom correspondant
           
            idCorrect = true; //La condition devient vrai si l'identifiant est trouvé
            break;
          }
        }
        //On affiche résultat
        if (idCorrect)
        {
          // Lancement du menu principal après une pause pour voir le message de bienvenue
          MenuPrincipal.Menu(panier, userCode, userName);
        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"\n ❌ Numéro d'employé invalide!"); //Si l'entrée utilisateur ne correspond a aucune id
          Console.ResetColor();
        }
        
      }
    }
  }
}