using System;
using System.Collections.Generic;

class CaixaEletronico
{
    private decimal Saldo { get; set; }
    private decimal LimiteSaque { get; set; }
    private decimal LimiteDiario { get; set; }
    private decimal SaqueDiarioAtual { get; set; }
    private List<string> HistoricoTransacoes { get; set; }

    public CaixaEletronico(decimal saldoInicial, decimal limiteSaque, decimal limiteDiario)
    {
        Saldo = saldoInicial;
        LimiteSaque = limiteSaque;
        LimiteDiario = limiteDiario;
        SaqueDiarioAtual = 0.00m;
        HistoricoTransacoes = new List<string>();
    }

    public void VerificarSaldo()
    {
        Console.WriteLine($"Seu saldo atual é: R$ {Saldo}");
    }

    public void FazerDeposito()
    {
        Console.Write("Digite o valor do depósito: R$ ");
        decimal deposito = Convert.ToDecimal(Console.ReadLine());
        if (deposito > 0)
        {
            Saldo += deposito;
            HistoricoTransacoes.Add($"Depósito: +R$ {deposito} - Novo saldo: R$ {Saldo}");
            Console.WriteLine($"Depósito de R$ {deposito} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Valor de depósito inválido!");
        }
    }

    public void FazerSaque()
    {
        Console.WriteLine($"Seu limite de saque por transação é de R$ {LimiteSaque}");
        Console.WriteLine($"Você pode sacar até R$ {LimiteDiario - SaqueDiarioAtual} hoje.");
        Console.Write("Digite o valor do saque: R$ ");
        decimal saque = Convert.ToDecimal(Console.ReadLine());

        if (saque > 0 && saque <= Saldo && saque <= LimiteSaque && (SaqueDiarioAtual + saque) <= LimiteDiario)
        {
            Saldo -= saque;
            SaqueDiarioAtual += saque;
            HistoricoTransacoes.Add($"Saque: -R$ {saque} - Novo saldo: R$ {Saldo}");
            Console.WriteLine($"Saque de R$ {saque} realizado com sucesso!");
        }
        else if (saque > Saldo)
        {
            Console.WriteLine("Saldo insuficiente!");
        }
        else if (saque > LimiteSaque)
        {
            Console.WriteLine($"O valor do saque excede o limite permitido por transação de R$ {LimiteSaque}.");
        }
        else if ((SaqueDiarioAtual + saque) > LimiteDiario)
        {
            Console.WriteLine($"O valor do saque excede o limite diário de R$ {LimiteDiario}.");
        }
        else
        {
            Console.WriteLine("Valor de saque inválido!");
        }
    }

    public void MostrarHistorico()
    {
        Console.WriteLine("\n=== Histórico de Transações ===");
        if (HistoricoTransacoes.Count == 0)
        {
            Console.WriteLine("Nenhuma transação realizada.");
        }
        else
        {
            foreach (string transacao in HistoricoTransacoes)
            {
                Console.WriteLine(transacao);
            }
        }
    }
}
