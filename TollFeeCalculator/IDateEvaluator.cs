namespace TollFeeCalculator;

public interface IDateEvaluator
{
    public bool IsTollFreeDate(DateTime date);
}