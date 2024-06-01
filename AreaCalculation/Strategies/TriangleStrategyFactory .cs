using AreaCalculation.Contracts;

namespace AreaCalculation.Strategies;

public class TriangleStrategyFactory: IAreaFactory
{
    public IAreaStrategy CreateStrategy(params double[] parameters)
    {
        if (parameters.Length != 3)
        {
            throw new ArgumentException("Triangle requires exactly three parameters: sideA, sideB, and sideC.");
        }
        return new TriangleStrategy(parameters[0], parameters[1], parameters[2]);
    }
}