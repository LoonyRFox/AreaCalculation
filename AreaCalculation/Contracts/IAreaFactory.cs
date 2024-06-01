namespace AreaCalculation.Contracts;

public interface IAreaFactory
{
    IAreaStrategy CreateStrategy(params double[] parameters);
}