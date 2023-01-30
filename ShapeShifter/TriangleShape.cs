using System.Collections.Generic;
using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class TriangleShape : Shape
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public TriangleShape(Point location) : base(location)
        {
            // PASS
        }

        /// <summary>
        /// Тип
        /// </summary>
        public override ShapeType Type => ShapeType.Triangle;

        /// <summary>
        /// Представление в виде массива точек в порядке построения
        /// </summary>
        /// <returns></returns>
        protected override PointF[] ShapePoints
        {
            get
            {
                Rectangle box = new Rectangle(Location, Size);

                PointF[] result = new PointF[]
                {
                    new PointF(box.Right, box.Top + box.Height / 2),
                    new PointF(box.Left, box.Bottom),
                    new PointF(box.Left, box.Top)
                };
                
                return result;
            }
        }
    }
}
