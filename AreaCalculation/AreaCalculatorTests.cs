using AreaCalculation;
using System;
using AreaCalculation.Contracts;
using AreaCalculation.Strategies;
using Xunit;

namespace AreaCalculation
{
    public class AreaCalculatorTests
    {
        [Fact]
        public void CalculateCircleArea_WithValidRadius_ReturnsCorrectArea()
        {
            
            var radius = 5.0;
            var expectedArea = Math.PI * radius * radius;
            var areaContext = new AreaCalculator();
            areaContext.RegisterStrategyFactory("Circle", new CircleStrategyFactory());

           
            var actualArea = areaContext.CalculateArea("Circle", radius);

            
            Assert.Equal(expectedArea, actualArea, precision: 5);
        }

        [Fact]
        public void CalculateTriangleArea_WithValidSides_ReturnsCorrectArea()
        {
            
            var sideA = 3.0;
            var sideB = 4.0;
            var sideC = 5.0;
            var semiPerimeter = (sideA + sideB + sideC) / 2;
            var expectedArea = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            var areaContext = new AreaCalculator();
            areaContext.RegisterStrategyFactory("Triangle", new TriangleStrategyFactory());

           
            var actualArea = areaContext.CalculateArea("Triangle", sideA, sideB, sideC);

           
            Assert.Equal(expectedArea, actualArea, precision: 5);
        }

        [Fact]
        public void CalculateArea_WithInvalidShapeType_ThrowsInvalidOperationException()
        {
            
            var areaContext = new AreaCalculator();

            
            Assert.Throws<InvalidOperationException>(() => areaContext.CalculateArea("Square", 4));
        }

        [Fact]
        public void CreateCircleAreaStrategy_WithInvalidParameters_ThrowsArgumentException()
        {
            
            var factory = new CircleStrategyFactory();

            
            Assert.Throws<ArgumentException>(() => factory.CreateStrategy(1, 2));
        }

        [Fact]
        public void CreateTriangleAreaStrategy_WithInvalidParameters_ThrowsArgumentException()
        {
            
            var factory = new TriangleStrategyFactory();

           
            Assert.Throws<ArgumentException>(() => factory.CreateStrategy(1, 2));
        }
    }
}
