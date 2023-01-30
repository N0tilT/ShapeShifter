using System.Collections.Generic;
using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Стрелка
    /// </summary>
    public class ArrowShape : Shape
    {
        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public ArrowShape()
        {
            // PASS
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public ArrowShape(Point location) : base(location)
        {
            // PASS
        }

        /// <summary>
        /// Тип
        /// </summary>
        public override ShapeType Type => ShapeType.Arrow;

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
                    new PointF(box.Left + box.Width / 2, box.Top),
                    new PointF(box.Right, box.Top + box.Height / 2),
                    new PointF(box.Left + box.Width / 2, box.Bottom),
                    new PointF(box.Left + box.Width / 2, box.Bottom - box.Height / 3),
                    new PointF(box.Left, box.Bottom - box.Height / 3),
                    new PointF(box.Left, box.Top + box.Height / 3),
                    new PointF(box.Left + box.Width / 2, box.Top + box.Height / 3)
                };

                return result;
            }
        }
    }
}
