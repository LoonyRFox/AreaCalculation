using AreaCalculation.Contracts;

namespace AreaCalculation.Strategies;

public class CircleStrategyFactory : IAreaFactory
{
    public IAreaStrategy CreateStrategy(params double[] parameters)
    {
        if (parameters.Length != 1)
        {
            throw new ArgumentException("Circle requires exactly one parameter: radius.");
        }
        return new CircleStrategy(parameters[0]);
    }
}