namespace api.Extensions
{
    public static class CreditCardExtensions
    {
        public static string FirstFourNumbers(string creditCard)
        {
            return creditCard.Substring(0, 4);
        }

        public static string LastFourNumbers(string creditCard)
        {
            return creditCard.Substring(creditCard.Length - 4);
        }

        public static bool ValidCreditCardFirstNumbers(string creditCard)
        {
            return !FirstFourNumbers(creditCard).Equals("5999");
        } 
    }
}
