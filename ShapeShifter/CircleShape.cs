using System.Drawing.Drawing2D;
using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Круг
    /// </summary>
    public class CircleShape : Shape
    {
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

        /// <summary>
        /// Порядок графического построения
        /// </summary>
        public override GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();

                path.AddEllipse(new RectangleF(Location, Size));

                return path;
            }
        }
    }
}
