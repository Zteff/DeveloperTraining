namespace Workshop2.StringCalculator;

public class StringCalculator
{
    public int Add(string numbersAsString)
    {
        if (string.IsNullOrEmpty(numbersAsString))
            return 0;

        numbersAsString = numbersAsString.Trim(',');
        
        var splitNumberStrings = numbersAsString.Split(',');
        var finalNumberInts = new List<int>();

        foreach (var numberString in splitNumberStrings)
        {
            if (!int.TryParse(numberString, out var number))
                throw new ArgumentException("Invalid argument - string contains non-numbers.");
            
            if (number < 0)
                continue;
            
            finalNumberInts.Add(number);
        }

        return finalNumberInts.Sum();
    }
}