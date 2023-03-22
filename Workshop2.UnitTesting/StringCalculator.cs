namespace Workshop2.UnitTesting;

public class StringCalculator
{
    private readonly ITaxable _taxable;
    public StringCalculator(ITaxable taxable)
    {
        _taxable = taxable;
    }
    public int Add(string stringNumber)
    {
        if (!string.IsNullOrEmpty(stringNumber))
        {
            if (stringNumber[^1].ToString() == ",")
                stringNumber = stringNumber.Remove(stringNumber.Length-1);
                
            var stringNumberArray = stringNumber.Split(",");
            var numberArray = new List<int>();

            foreach (var strNumber in stringNumberArray)
            {
                if (!int.TryParse(strNumber, out var num))
                    throw new ArgumentException("Invalid input, string contain non numbers");
                
                numberArray.Add(num);
            }

            var sum = numberArray.Where(x => x > 0).Sum();

            if (_taxable.IsTaxable(sum))
                return (int) (sum * 1.5);

            return sum;
        }

        return 0;
    }
}