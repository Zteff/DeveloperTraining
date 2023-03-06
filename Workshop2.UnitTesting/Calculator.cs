namespace Workshop2.UnitTesting;

public class Calculator
{
    public int Add(int[] numbersToAdd)
    {
        if (!numbersToAdd.Any())
            return 0;
        return numbersToAdd[0];
    }
}