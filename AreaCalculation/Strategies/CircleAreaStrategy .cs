using AreaCalculation.Contracts;

namespace AreaCalculation.Strategies;

public class CircleStrategy : IAreaStrategy
{
    private readonly double _radius;
    public CircleStrategy(double radius)
    {
        _radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
}