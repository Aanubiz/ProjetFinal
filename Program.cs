using System;
using System.Collections.Generic; 

namespace ProjetFinal
{
  class Program
  {
     static void Main()
    {
      /*-- pour que le code accepte les emodji --*/ 
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      /* -- declaration du liste panier 
      Cette liste est déclaré dans le Main car 
      elle sera appelé dans d'autres procédures--*/
      List<(string code, string nom, decimal prix)> panier = new();
      
      /*-- Appel de la procédure Authetification --*/
      Authentification.CodeUtilisateur(panier);
      
     
    }
  }
}
