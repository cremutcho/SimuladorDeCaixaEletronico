using System;

class Program
{
    static void Main(string[] args)
    {
        Usuario usuario = new Usuario("1234"); // Cria o usuário com uma senha
        CaixaEletronico caixa = new CaixaEletronico(1000.00m, 500.00m, 1000.00m); // Cria o caixa com saldo inicial, limite de saque e limite diário

        if (!usuario.Autenticar())
        {
            Console.WriteLine("Senha incorreta. Acesso negado!");
            return;
        }

        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n=== Simulador de Caixa Eletrônico ===");
            Console.WriteLine("1. Verificar saldo");
            Console.WriteLine("2. Fazer depósito");
            Console.WriteLine("3. Fazer saque");
            Console.WriteLine("4. Ver histórico de transações");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    caixa.VerificarSaldo();
                    break;

                case "2":
                    caixa.FazerDeposito();
                    break;

                case "3":
                    caixa.FazerSaque();
                    break;

                case "4":
                    caixa.MostrarHistorico();
                    break;

                case "5":
                    sair = true;
                    Console.WriteLine("Obrigado por utilizar o caixa eletrônico. Até logo!");
                    break;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }
}


