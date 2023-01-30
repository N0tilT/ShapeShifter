using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Прямоугольник
    /// </summary>
    public class RectangleShape : Shape
    {
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public RectangleShape()
        {
            // PASS
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public RectangleShape(PointF location) : base(location)
        {
            // PASS
        }

        /// <summary>
        /// Тип
        /// </summary>
        public override ShapeType Type => ShapeType.Rectangle;
    }
}
