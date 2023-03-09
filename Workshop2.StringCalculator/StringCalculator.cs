namespace Workshop2.StringCalculator;

public class StringCalculator
{
    public int Add(string numbersAsString)
    {
        var splitNumberStrings = numbersAsString.Split(',');
        var finalNumberInts = new List<int>();

        foreach (var numberString in splitNumberStrings)
        {
            if (!int.TryParse(numberString, out var number))
                throw new ArgumentException("Invalid argument - string contains non-numbers.");
            
            finalNumberInts.Add(number);
        }

        return finalNumberInts.Sum();
    }
}