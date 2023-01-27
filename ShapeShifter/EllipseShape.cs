using System.Drawing;
using System.Drawing.Drawing2D;

namespace ShapeShifter
{
    /// <summary>
    /// Эллипс
    /// </summary>
    public class EllipseShape : Shape
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public EllipseShape(Point location) : base(location)
        {
            // PASS
        }

        /// <summary>
        /// Тип
        /// </summary>
        public override ShapeType Type => ShapeType.Ellipse;

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
