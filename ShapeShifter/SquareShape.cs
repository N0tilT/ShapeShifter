using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Квадрат
    /// </summary>
    public class SquareShape : RectangleShape
    {
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public SquareShape()
        {
            // PASS
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public SquareShape(PointF location) : base(location)
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
        public override SizeF Size
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
