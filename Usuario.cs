using System;

class Usuario
{
    private string Senha { get; set; }

    public Usuario(string senha)
    {
        Senha = senha;
    }

    public bool Autenticar()
    {
        Console.Write("Digite sua senha: ");
        string entradaSenha = Console.ReadLine();
        return entradaSenha == Senha;
    }
}
