using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Прямоугольник
    /// </summary>
    public class RectangleShape : Shape
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public RectangleShape(Point location) : base(location)
        {
            // PASS
        }

        /// <summary>
        /// Тип
        /// </summary>
        public override ShapeType Type => ShapeType.Rectangle;
    }
}
