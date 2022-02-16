using System;

namespace Aula01
{
    public class Pessoa
{
    private string nome = "initial";
    private string genero = "masculino";
    private int idade;

    public void SetNome(string nome)
    {
        this.nome = nome;
    }

    public string GetNome()
    {
        return nome;
    }

    public string GetGenero()
    {
        return genero;
    }

    public void SetGenero(string genero)
    {
        this.genero = genero;
    }

    public int GetIdade()
    {
        return idade;
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











