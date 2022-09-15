using static System.Console;
#nullable disable

namespace CSharp_Six;


class Program
{
    static void Main()
    {
        BankCard card1 = new BankCard("Kapital Bank", "Elshad Hasanov", "1234567812345678", "2005", "198", new DateOnly(2022, 10, 1), 5);
        BankCard card2 = new BankCard("UniBank", "Elxan Hasanov", "1234567812345678", "1998", "198", new DateOnly(2022, 10, 1), 100);
        BankCard card3 = new BankCard("RabiteBank", "Elman Hasanov", "1234567812345678", "2008", "198", new DateOnly(2022, 10, 1), 100);
        BankCard card4 = new BankCard("LeoBank", "Polad Hasanov", "1234567812345678", "2007", "198", new DateOnly(2022, 10, 1), 100);
        BankCard card5 = new BankCard("YeloBank", "Elgun Hasanov", "1234567812345678", "2003", "198", new DateOnly(2022, 10, 1), 100);

        Client client1 = new Client("Elshad", "Hasanov", card1);
        Client client2 = new Client("Elxan", "Hasanov", card2);
        Client client3 = new Client("Elman", "Hasanov", card3);
        Client client4 = new Client("Polad", "Hasanov", card4);
        Client client5 = new Client("Elgun", "Hasanov", card5);

        Client[] clients = { client1, client2, client3, client4, client5 };

        while (true)
        {
            int CurrentIndex = -1;
            Clear();
            WriteLine("Enter Your Pin: ");
            string pin = ReadLine();

            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i].card.PIN == pin)
                {
                    CurrentIndex = i;
                    break;
                }
            }

            if (CurrentIndex != -1)
            {
                while (true)
                {
                    Clear();
                    WriteLine($"{clients[CurrentIndex].name} {clients[CurrentIndex].surname} Welcome!");
                    ReadKey(false);
                    Clear();
                    WriteLine("1)Balance\n2)Cash\n3)Operations List\n4)Card to Card\nChoose Operation: ");
                    string operation = ReadLine();
                    switch (operation)
                    {
                        case "1":
                            WriteLine($"Balance: {clients[CurrentIndex].card.BALANS} AZN");
                            ReadKey(false);
                            break;
                        case "2":
                            {
                                WriteLine("1) 10 AZN\n2) 20 AZN\n3) 50 AZN\n4) 100 AZN\n5)Other");
                                string cash_opr = ReadLine();
                                switch (cash_opr)
                                {
                                    case "1":
                                        {
                                            if (clients[CurrentIndex].card.Balans < 10)
                                            {
                                                WriteLine("There is not enough money in your balance!");
                                                ReadKey(false);
                                                Environment.Exit(0);
                                            }
                                            else
                                            {
                                                clients[CurrentIndex].card.Balans -= 10;
                                                clients[CurrentIndex].log += "10 Azn has been deducted from your balance\n";
                                            }

                                            break;
                                        }
                                    case "2":
                                        {
                                            if (clients[CurrentIndex].card.Balans < 20)
                                            {
                                                WriteLine("There is not enough money in your balance!");
                                                ReadKey(false);
                                                Environment.Exit(0);
                                            }
                                            else
                                            {
                                                clients[CurrentIndex].card.Balans -= 20;
                                                clients[CurrentIndex].log += "20 Azn has been deducted from your balance\n";
                                            }

                                            break;
                                        }
                                    case "3":
                                        {
                                            if (clients[CurrentIndex].card.Balans < 50)
                                            {
                                                WriteLine("There is not enough money in your balance!");
                                                ReadKey(false);
                                                Environment.Exit(0);
                                            }
                                            else
                                            {
                                                clients[CurrentIndex].card.Balans -= 50;
                                                clients[CurrentIndex].log += "50 Azn has been deducted from your balance\n";
                                            }

                                            break;
                                        }
                                    case "4":
                                        {
                                            if (clients[CurrentIndex].card.Balans < 100)
                                            {
                                                WriteLine("There is not enough money in your balance!");
                                                ReadKey(false);
                                                Environment.Exit(0);
                                            }
                                            else
                                            {
                                                clients[CurrentIndex].card.Balans -= 100;
                                                clients[CurrentIndex].log += "100 Azn has been deducted from your balance\n";
                                            }

                                            break;
                                        }
                                    case "5":
                                        {
                                            int amount;
                                            Write("Enter Amount: ");
                                            if (!int.TryParse(ReadLine(), out amount))
                                                throw new ArgumentException("You can only write a number here");

                                            if (amount > clients[CurrentIndex].card.Balans)
                                            {

                                                WriteLine("There is not enough money in your balance!");
                                                ReadKey(false);
                                                Environment.Exit(0);
                                            }

                                            clients[CurrentIndex].card.Balans -= amount;
                                            clients[CurrentIndex].log += $"{amount} Azn has been deducted from your balance\n";
                                            break;
                                        }
                                    default:
                                        WriteLine("Incorrect Operation!");
                                        ReadKey(false);
                                        Environment.Exit(0);
                                        break;
                                }
                                break;
                            }
                        case "3":
                            Clear();
                            WriteLine(clients[CurrentIndex].log);
                            ReadKey(false);
                            break;
                        case "4":
                            {
                                Write("Enter Other Client Pin: ");
                                string other_pin = ReadLine();
                                for (int i = 0; i < clients.Length; i++)
                                {
                                    if (clients[i].card.PIN == other_pin)
                                    {
                                        int amount;
                                        Write("Enter Amount: ");
                                        if (!int.TryParse(ReadLine(), out amount))
                                            throw new ArgumentException("You can only write a number here");

                                        if (amount > clients[CurrentIndex].card.Balans)
                                        {

                                            WriteLine("There is not enough money in your balance!");
                                            ReadKey(false);
                                            Environment.Exit(0);
                                        }

                                        clients[i].card.Balans += amount;
                                        clients[CurrentIndex].card.Balans -= amount;
                                        break;
                                    }
                                }
                                break;
                            }
                        default:
                            WriteLine("Incorrect Operation!");
                            ReadKey(false);
                            break;
                    }
                    break;
                }
            }
            else
            {
                WriteLine("Daxil Etdiyiniz Pin Tapilmadi!\n");
                ReadKey(false);
            }
        }
    }
}