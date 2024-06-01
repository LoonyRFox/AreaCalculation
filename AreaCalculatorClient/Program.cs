// See https://aka.ms/new-console-template for more information

using AreaCalculation;
using AreaCalculation.Strategies;

Console.WriteLine("Hello, AreaCalculator!");

var areaContext = new AreaCalculator();


areaContext.RegisterStrategyFactory("Circle", new CircleStrategyFactory());
areaContext.RegisterStrategyFactory("Triangle", new TriangleStrategyFactory());

double circleArea = areaContext.CalculateArea("Circle", 5);
Console.WriteLine($"Площадь круга: {circleArea}");

double triangleArea = areaContext.CalculateArea("Triangle", 3, 4, 5);
Console.WriteLine($"Площадь треугольника: {triangleArea}");


Console.ReadKey();