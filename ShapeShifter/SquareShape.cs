using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Квадрат
    /// </summary>
    public class SquareShape : RectangleShape
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public SquareShape(Point location) : base(location)
        {
            // PASS
        }

        /// <summary>
        /// Тип
        /// </summary>
        public override ShapeType Type => ShapeType.Square;

        /// <summary>
        /// Доступ к размеру
        /// </summary>
        public override Size Size
        {
            set
            {
                // Нормализация размера
                value.Height = value.Width;

                base.Size = value;
            }
        }
    }
}
