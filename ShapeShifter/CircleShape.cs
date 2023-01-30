using System.Drawing.Drawing2D;
using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Круг
    /// </summary>
    public class CircleShape : EllipseShape
    {
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public CircleShape()
        {
            // PASS
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public CircleShape(Point location) : base(location)
        {
            // PASS
        }
        
        /// <summary>
        /// Тип
        /// </summary>
        public override ShapeType Type => ShapeType.Circle;

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
