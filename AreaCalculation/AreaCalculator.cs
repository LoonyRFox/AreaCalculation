using AreaCalculation.Contracts;
/// Думал над "Вычисление площади фигуры без знания типа фигуры в compile-time"
/// была идея рассматривать только параметры и по ним выбирать фабрику для алгоритма,
/// но идея не рабочая так как для площади квадрата нам нужна или  длина диагонали
/// или длина стороны (результат одинаковый но алгоритмы разные), то есть 1 параметр как и у круга.
/// Сплошная неоднозначность. Когда фигуры две (круг и треугольник) не проблема, но при расширении
/// базы алгоритмов все сломается.
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
