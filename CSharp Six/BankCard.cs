#nullable disable

namespace CSharp_Six
{
    public class BankCard
    {
        public string? Bankname;
        public string? Fullname;
        public string? Pan;
        public string? Pin;
        public string? Cvc;
        public DateOnly ExpireDate;
        public int Balans;

        public BankCard(string? bankname, string? fullname, string? pan, string? pin, string? cvc, DateOnly expireDate, int balans)
        {
            Bankname = bankname;
            Fullname = fullname;
            PAN = pan;
            PIN = pin;
            CVC = cvc;
            ExpireDate = expireDate;
            BALANS = balans;
        }

        public string PAN
        {
            get { return Pan; }
            set
            {
                if (value.Length != 16)
                    throw new InvalidDataException("PAN kodun uzunluğu 16 rəqəm olmalıdır!");
                else if (!value.All(char.IsDigit))
                    throw new InvalidDataException("PAN kodun bütün simvolları rəqəm olmalıdır!");
                else
                    Pan = value;
            }
        }
        public string PIN
        {
            get { return Pin; }
            set
            {
                if (value.Length != 4)
                    throw new InvalidDataException("PIN kodun uzunluğu 4 rəqəm olmalıdır!");
                else if (!value.All(char.IsDigit))
                    throw new InvalidDataException("PIN kodun bütün simvolları rəqəm olmalıdır!");
                else
                    Pin = value;
            }
        }
        public string CVC
        {
            get { return Cvc; }
            set
            {
                if (value.Length != 3)
                    throw new InvalidDataException("CVC kodun uzunluğu 3 rəqəm olmalıdır!");
                else if (!value.All(char.IsDigit))
                    throw new InvalidDataException("CVC kodun bütün simvolları rəqəm olmalıdır!");
                else
                    Cvc = value;
            }
        }
        public int BALANS
        {
            get { return Balans; }
            set
            {
                if (value < 0)
                    Balans = 0;
                else
                    Balans = value;
            }
        }

        public override string ToString()
        {
            return $@"
BankName: {Bankname}
FullName: {Fullname}
PAN: {PAN}
PIN: {PIN}
CVC: {CVC}
Balans: {BALANS} AZN
ExpireData: {ExpireDate.Month}/{ExpireDate.Year}";
        }
    }
}
