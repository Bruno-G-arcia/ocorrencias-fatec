using System;

namespace Aula01{
    public class Program{
         static void Main() {
            Pessoa joao = new Pessoa();
            joao.SetNome("joao");
            Console.WriteLine(joao.GetNome());
            joao.SetIdade(35);
            Console.WriteLine(joao.GetIdade());                        
        }               

    }
   
}