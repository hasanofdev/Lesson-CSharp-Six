#nullable disable

namespace CSharp_Six
{
    public class Client
    {
        public string name;
        public string surname;
        public BankCard card;
        public string log;

        public Client(string name, string surname, BankCard card)
        {
            this.name = name;
            this.surname = surname;
            this.card = card;
        }

        public override string ToString()
        {
            return $@"
Name: {name}
Surname: {surname}
{card}";
        }
    }
}
