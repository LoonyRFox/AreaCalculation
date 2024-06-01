using AreaCalculation.Contracts;

namespace AreaCalculation.Strategies;

public class TriangleStrategy : IAreaStrategy
{
    private readonly double _sideA;
    private readonly double _sideB;
    private readonly double _sideC;

    public TriangleStrategy(double sideA, double sideB, double sideC)
    {
        _sideA = sideA;
        _sideB = sideB;
        _sideC = sideC;
    }

    public double CalculateArea()
    {
        double semiPerimeter = (_sideA + _sideB + _sideC) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
    }

  
}