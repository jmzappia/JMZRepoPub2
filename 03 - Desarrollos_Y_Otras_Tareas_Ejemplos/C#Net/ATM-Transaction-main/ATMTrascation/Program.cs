/*************************************************************************************************************
* Programa: Program.cs                                                                                       *
**************************************************************************************************************
* Descripción: Ejemplo de consola                                                                            *
* Autor      : Julián Marcelo Zappia                                                                         *
* Fecha      : 15/04/2017                                                                                    *
*************************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTransaccion
{
    class Program
    {
        public static void Main(string[] args)
        {
            int amount = 1000, deposit, withdraw;

            int choice, pin = 0, x = 0;

            Console.WriteLine("Ingrese su número de PIN: ");

            pin = int.Parse(Console.ReadLine());

            while (true)

            {

                Console.WriteLine("\n*************Bienvenido al servicio ATM************\n");

                Console.WriteLine("1. Chequear Balance\n");

                Console.WriteLine("2. Retirar Efectivo\n");

                Console.WriteLine("3. Depositar\n");

                Console.WriteLine("4. Salir\n");

                Console.WriteLine("*******************************************************\n\n");

                Console.WriteLine("Ingrese la opción deseada: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)

                {

                    case 1:

                        Console.WriteLine("\n Su Balance en $ : {0} ", amount);

                        break;

                    case 2:

                        Console.WriteLine("\n Ingrese el monto a retirar: ");

                        withdraw = int.Parse(Console.ReadLine());

                        if (withdraw % 100 != 0)
                        {

                            Console.WriteLine("\n Por favor, ingrese valores múltiplos de 100.");

                        }

                        else if (withdraw > amount - 500)

                        {

                            Console.WriteLine("\n Fondos insuficientes.");

                        }

                        else

                        {

                            amount = amount - withdraw;

                            Console.WriteLine("\n\n Por favor, retire su dinero.");

                            Console.WriteLine("\n Su Balance Actual es $ {0}", amount);

                        }

                        break;

                    case 3:

                        Console.WriteLine("\n Ingrese el monto a depositar.");

                        deposit = int.Parse(Console.ReadLine());

                        amount = amount + deposit;

                        Console.WriteLine("Su saldo disponible es de $ {0}", amount);

                        break;

                    case 4:

                        Console.WriteLine("\n Gracias por usar ATM\n");

                        break;

                }
            }
            Console.WriteLine("\n\n Gracias por usar los servicios de ATM");
        }
    }
}
