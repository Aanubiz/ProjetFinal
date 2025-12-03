using System;
using System.Collections.Generic; 

namespace ProjetFinal
{
  class Program
  {
     static void Main()
    {
      // pour que le code accepte les emodji 
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      // declaration du liste panier
      List<(string code, string nom, decimal prix)> panier = new List<(string code, string nom, decimal prix)>();
      
      Authentification.CodeUtilisateur();
     
    }
  }
}
