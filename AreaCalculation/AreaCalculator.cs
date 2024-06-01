using AreaCalculation.Contracts;

namespace AreaCalculation
{
    public class AreaCalculator
    {
        private readonly Dictionary<string, IAreaFactory> _factories;

        public AreaCalculator()
        {
            _factories = new Dictionary<string, IAreaFactory>();
        }
        /// <summary>
        /// Добавляет в коллекцию алгоритмов, тип фигуры и алгоритм для расчета её площеади
        /// </summary>
        /// <param name="shapeType">тип фигуры</param>
        /// <param name="factory">Фабрика агроритма</param>
        public void RegisterStrategyFactory(string shapeType, IAreaFactory factory)
        {
            _factories[shapeType] = factory;
        }
        /// <summary>
        /// Производит расчет площади геометрической фигуры
        /// </summary>
        /// <param name="shapeType">Тип фигуры</param>
        /// <param name="parameters">Параметры расчета</param>
        /// <returns>Площачд фигуры</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public double CalculateArea(string shapeType, params double[] parameters)
        {
            if (!_factories.ContainsKey(shapeType))
            {
                throw new InvalidOperationException($"Нет фабрики для заданного типа фигуры: {shapeType}");
            }

            var strategy = _factories[shapeType].CreateStrategy(parameters);
            return strategy.CalculateArea();
        }
    }
}
