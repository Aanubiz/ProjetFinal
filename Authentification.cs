using System;
using System.Collections.Generic; 

namespace ProjetFinal
{
  class Authentification
  {
     /*-- Cette méthode gère la connexion de l'employé et lance le menu --*/
     /// <summary> Authentification des employés </summary>
     // 
     // Cette méthode permet d'authentifier l'employé. Pour cela, elle stock le nom et les identifiants dans un tableau
     // l'objectif est d'autoriser l'accès seulement au employés deja connu par le système. c'est pour cela que le
     // programme démarre avec une boucle 'while' qui vérifie la variable booléenne qui est déclaré. Cette variable est 
     // fausse et tant que cela reste vrai que le variable est dans cet état, le programe demande à l'employé de se cnnecté
     // Dès lorsque que la variable booléenne devient vrai, c'est a dire que son contenu passe de faux a vrai, cela signifiera
     // que l'utilisateur à entré un
     // 
     /// <param name="panier"></param>
    public static void CodeUtilisateur(List<(string code, string nom, decimal prix)> panier)
    {
      /*-- Déclaration de variable --*/
      string [] id = {"001", "002", "003", "004", "005"}; //-- Tableau des identifiants
      string [] noms = {"samir", "Mohamed", "Afef", "Jean-Gabriel", "Eve"}; //-- Tableau des noms

      bool idCorrect = false; //-- Vérifier si l'utilisateur entre une id correct
      string userName = "";  //-- Stock le nom correspondant à l'entrée de utilisateur
      string userCode = ""; //-- Stock l'identifiant correspondant à l'entrée de utilisateur
      
      while (!idCorrect) //-- Si idCorrect == false, la condition est vrai donc la boucle continue
      {
        Console.WriteLine("_________________________________");
        Console.Write("Veuillez saisir votre identifiant\n => ");
         
        string idEntré = Console.ReadLine(); //-- Entrée utilisateur
        for (int i = 0; i < id.Length; i++)
        {
          //On compare l'id entrée avec ceux qui existent dans le tableau
          if (id[i] == idEntré)
          {
            userName = noms[i]; //-- On récupère le nom correspondant
            userCode = id[i]; //-- On récupère l'identifiant correspondant
           
            idCorrect = true; //-- La condition devient vrai si l'identifiant est trouvé
            break;
          }
        }
        
        if (idCorrect)
        {
          //-- Ouverture du menu principal
          MenuPrincipal.Menu(panier, userCode, userName);
        }
        else
        {
          //-- Si l'entrée utilisateur ne correspond a aucune id
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"\n ❌ Numéro d'employé invalide!"); 
          Console.ResetColor();
        }
        
      }
    }
  }
}