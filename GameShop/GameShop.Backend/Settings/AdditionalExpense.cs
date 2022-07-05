namespace GameShop.Backend.Settings
{
    public class AdditionalExpense
    {
        public string Name { get; set; }
        public double PricePercentage { get; set; }
        public double FixedAmount { get; set; }

        public AdditionalExpense(string name, double pricePercentage, double fixedAmount)
        {
            Name = name;
            PricePercentage = pricePercentage;
            FixedAmount = fixedAmount;
        }


        public override string ToString()
        {
            return Name + " " + ((PricePercentage != 0) ? PricePercentage + "%" : FixedAmount + GlobalSettings.Instance.Currency.ToString());
        }
    }
}
