using System;
using System.Globalization;

namespace ContadorDeDias
{
    internal class Program
    {
        public static CultureInfo culture = new CultureInfo("pt-BR");
        public static DateTimeFormatInfo dtfi = culture.DateTimeFormat;
        static void Main(string[] args)
        {
            Console.WriteLine("Olá, digite o dia que pretende inputar dia/mes/ano");

            DateTime dataInput = new DateTime(2019, 02, 12);
            dataInput = Convert.ToDateTime(Console.ReadLine());
            DateTime dataHoje = new DateTime();
            dataHoje = DateTime.Now;

            bool menuMes = true;
            int resultado = (dataHoje - dataInput).Days;
            int resultadoVerif = resultado;
            int sobraDiasMes = 1;
            int sobraDiasSemana = 1;


            //ALGUNS DIAS
            if (resultado <= 7)
            Console.WriteLine($"Estamos falando de: {resultado} Dia(s) atrás");

            
            //SEMANAS
            if (resultado > 7 && resultado < 30)
            {
                for (int i = 0; i < 50; i++)
                {
                    resultadoVerif = resultado;
                    int checkSemana = resultadoVerif % 7;

                    if (checkSemana != 0)
                    {
                        resultadoVerif--;
                        continue;
                    }
                    else if (checkSemana == 0)
                    {
                        Console.WriteLine($"Estamos falando de: {resultadoVerif/7} Semanas,\nE {resultado - resultadoVerif} dias atrás");
                        break;
                    }
                }
            }

            //MESES
            while (menuMes == true)
            {
                if (resultado > 364)
                    break;

                //paraMeses SEM semanas
                double verifSemSemanas1 = Convert.ToDouble(resultado);
                verifSemSemanas1 = verifSemSemanas1 / 30;
                double verifSemSemanas2 = resultado / 30;
                double verificadorSemSemanas = verifSemSemanas1 - verifSemSemanas2;
                int moduloMes = resultadoVerif % 30;

                if (verificadorSemSemanas < 0.231 && verificadorSemSemanas > 0.01)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        int checkMes = resultadoVerif % 30;

                        if (checkMes != 0)
                        {
                            resultadoVerif--;
                            continue;
                        }
                        else if (checkMes == 0)
                        {
                            Console.Write($"\nEstamos falando de: {resultadoVerif / 30} Mês(es) e {moduloMes} Dia(s)");                            
                            break;
                        }
                    }
                    break;                 
                }



                if (resultado > 30 && resultado < 364)
                {
                    resultadoVerif = resultado;
                    int checkMes = 1;
                    sobraDiasMes = checkMes;
                    sobraDiasMes = resultadoVerif % 30;

                    //VerifMes
                    for (int i = 0; i < 1000; i++)
                    {
                        checkMes = resultadoVerif % 30;

                        if (checkMes != 0)
                        {
                            resultadoVerif--;
                            continue;
                        }
                        else if (checkMes == 0)
                        {
                            Console.Write($"\nEstamos falando de: {resultadoVerif / 30} Mês(es),");
                            resultadoVerif = sobraDiasMes;
                            sobraDiasSemana = sobraDiasMes % 7;
                            break;
                        }
                    }

                    //SEMANAS
                    if (sobraDiasMes >= 7 && sobraDiasMes < 30)
                    {
                        for (int i = 0; i < 50; i++)
                        {
                            int checkSemana = resultadoVerif % 7;

                            if (checkSemana != 0)
                            {
                                resultadoVerif--;
                                continue;
                            }
                            else if (checkSemana == 0)
                            {
                                Console.Write($" {resultadoVerif / 7} Semana(s), e {sobraDiasSemana} Dia(s) atrás\n\n");
                                break;
                            }

                        }
                    }
                } break;
            }

            if (resultado >= 365)
            {
                Console.WriteLine($"Estamos falando de {resultado/365} Ano(s) atrás");
            }
        }
    }
}
