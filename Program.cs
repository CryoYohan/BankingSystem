using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace AppDevDemo
{


    public class Base
    {
        public NumberFormatInfo precision = new NumberFormatInfo();
        public double balance = 0, withdrawcash = 0, depositcash = 0;
        string username, password;

        public double deposit(double deposit)
        {
            balance += deposit;
            return deposit;
        }

        public double withdraw(double withdraw)
        {
            if (withdraw > balance)
            {
                Console.WriteLine("Insufficient Balance");
                return 0;
            }              
            else
            {
                balance -= withdraw;
                return withdraw;
            }        

        }

        public double getBalance()
        {
            return balance;
        }
    }

    public class Child : Base
    {
        int password = 0;
        string username = "";
        Hashtable accounts = new Hashtable() { { "cyril123", 080808 } };

        public void startProgram()
        {
          
            bool start = true;
            while (start)
            {
                while (true)
                {
                    Console.WriteLine("BDO NETWORK\n\n1.] Login 2.] Exit");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if(num == 1)
                    {
                        if (login() == true)
                        {
                            start = system();
                        }
                           
                    }
                    else if(num==2)
                    {
                        start = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid");
                        continue;
                    }

                }
                

            }


        }

        public bool login()
        {
            bool success = false;
            Console.Write("\nBDO NETWORK\n\nUser:");
            username = Console.ReadLine();
            Console.Write("\n\nPassword: ");
            try
            {
                password = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException e)
            {
                Console.WriteLine("Error");
            }

            if (accounts.ContainsKey(username.Trim()) && accounts.ContainsValue(password))
            {
                Console.WriteLine("Logging in...");
                Thread.Sleep(1500);
                Console.WriteLine("Login Successful...");
                return success = true;
            }
            else if(accounts.ContainsKey(username.Trim()) || accounts.ContainsValue(password))
            {
                Console.WriteLine("Username/Password is incorrect");
                return success = false;
            }
            else
            {
                Console.WriteLine("Account does not exist");
                return success = false;
            }
        }

        public bool system()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("\nWelcome to BDO\n\n1.] DEPOSIT\n2.] WITHDRAW\n3.] BALANCE\n4.] Log-out:");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                { }
                switch (choice)
                {
                    case 1:
                        Console.Write("DEPOSIT:");
                        Console.Write("User deposited > ${0}\n", deposit(depositcash += Convert.ToDouble(Console.ReadLine())));
                        break;
                    case 2:
                        Console.Write("WITHDRAW:");
                        Console.Write("User withdrawed > ${0}\n", withdraw(withdrawcash = Convert.ToDouble(Console.ReadLine())));
                        break;
                    case 3:
                        precision.NumberDecimalDigits = 2;
                        Console.Write("BALANCE: ${0}\n", balance.ToString("N", precision));
                        break;
                    case 4:
                        Console.WriteLine("Logging Out...");
                        Thread.Sleep(1500);
                        Console.WriteLine("User Logged out");
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            } while (choice != 4);
            return false;


        }


    }



    class MainClass
    {
        public static void Main(string[] args)
        {
            Child c = new Child();
            c.startProgram();
        }
    }

}
