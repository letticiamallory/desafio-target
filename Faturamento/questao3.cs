using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Main
{
    public class Faturamento
    {
        public int dia { get; set; }
        public double valor { get; set; }
    }

    static void Main()
    {
        string json = File.ReadAllText("faturamento.json");
        List<Faturamento> faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(json);

        double menorValor = double.MaxValue;
        double maiorValor = double.MinValue;
        double soma = 0;
        int diasComFaturamento = 0;

        foreach (var faturamento in faturamentos)
        {
            if (faturamento.valor > 0)
            {
                if (faturamento.valor < menorValor)
                {
                    menorValor = faturamento.valor;
                }
                if (faturamento.valor > maiorValor)
                {
                    maiorValor = faturamento.valor;
                }
                soma += faturamento.valor;
                diasComFaturamento++;
            }
        }

        double mediaMensal = soma / diasComFaturamento;
        int diasAcimaDaMedia = 0;

        foreach (var faturamento in faturamentos)
        {
            if (faturamento.valor > mediaMensal)
            {
                diasAcimaDaMedia++;
            }
        }

        Console.WriteLine($"Menor valor de faturamento: {menorValor}");
        Console.WriteLine($"Maior valor de faturamento: {maiorValor}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
    }
}
