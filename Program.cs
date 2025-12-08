using System;
using System.Collections.Generic; 

namespace ProjetFinal
{
  class Program
  {
     static void Main()
    {
      /*-- pour afficher correctement les emojis dans le terminal --*/ 
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      /*-- declaration de la liste 'panier' 
      Cette liste est déclaré dans le Main car 
      elle sera appelé dans d'autres procédures --*/
      List<(string code, string nom, decimal prix)> panier = new();
      
      /*-- Appel de la procédure Authetification --*/
      Authentification.CodeUtilisateur(panier);
    }
  }
}
