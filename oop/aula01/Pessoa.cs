using System;

namespace Aula01
{
    internal class Pessoa
{
    private string nome;
    private string genero;
    private int idade;

    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public string GetNome()
    {
        Return nome;
    }

    public string GetGenero()
    {
        Return genero;
    }

    public void SetGenero(string genero)
    {
        this.genero = genero;
    }

    public int GetIdade()
    {
        Return idade;
    }

    public void SetIdade(int idade)
    {
        if (idade < 0)
        {
            throw new System.Exception("Idade Negativa");
        }
        this.idade = idade;
    }
}
    
}











