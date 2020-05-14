namespace CurrencyCalculator
{
    public abstract class BaseCurrency
    {
        public enum CurrencyTypes
        {
            Dollar,
            Euro
        }

        public double Value { get; set; }
        public CurrencyTypes Currency { get; set; }
        public string Symbol
        {
            get
            {
                switch (Currency)
                {
                    case CurrencyTypes.Dollar:
                        return "$";
                    case CurrencyTypes.Euro:
                        return "€";
                    default:
                        return "";
                }
            }
        }

        public BaseCurrency(double value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} {Symbol}";
        }
    }

    public class Dollar : BaseCurrency
    {
        public Dollar(double value) : base(value)
        {
            Currency = CurrencyTypes.Dollar;
        }

        public static implicit operator Euro(Dollar d)
        {
            return new Euro(d.Value * 0.83);
        }

        public static Dollar operator +(Dollar x1, Dollar x2)
        {
            return new Dollar(x1.Value + x2.Value);
        }

        public static Dollar operator +(Dollar x1, Euro x2)
        {
            return new Dollar(x1.Value + ((Dollar)x2).Value);
        }
    }

    public class Euro : BaseCurrency
    {
        public Euro(double value) : base(value)
        {
            Currency = CurrencyTypes.Euro;
        }

        public static implicit operator Dollar(Euro e)
        {
            return new Dollar(e.Value * 1.20);
        }

        public static Euro operator +(Euro x1, Dollar x2)
        {
            return new Euro(x1.Value + ((Euro)x2).Value);
        }
    }
}