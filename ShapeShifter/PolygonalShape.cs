using System;
using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Настраиваемая полигональная фигура
    /// </summary>
    public class PolygonalShape : Shape
    {
        /// <summary>
        /// Количество граней
        /// </summary>
        private int _sideCount;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        public PolygonalShape(Point location, int sideCount) : base(location)
        {
            SideCount = sideCount;
        }

        /// <summary>
        /// Тип
        /// </summary>
        public override ShapeType Type => ShapeType.Polygonal;

        /// <summary>
        /// Доступ к количеству граней
        /// </summary>
        public int SideCount
        {
            get => _sideCount;
            set
            {
                if (value <= 2 || value > 32)
                {
                    throw new ArgumentOutOfRangeException("Invalid SideCount");
                }

                _sideCount = value;
            }
        }

        /// <summary>
        /// Представление в виде массива точек в порядке построения
        /// </summary>
        /// <returns></returns>
        protected override PointF[] ShapePoints
        {
            get
            {
                Rectangle box = new Rectangle(Location, Size);

                // Определение координат центра
                // Промежуточные значения используются при построении
                PointF centerSide = new PointF(box.Width / 2.0f, box.Height / 2.0f);
                PointF center = new PointF(box.Left + centerSide.X, box.Top + centerSide.Y);

                double angle = 0.00;
                double vertex = 2 * Math.PI / SideCount;

                PointF[] result = new PointF[SideCount];

                for (int i = 0; i < SideCount; i++)
                {
                    result[i] = new PointF(
                        (float)(center.X + centerSide.X * Math.Cos(angle)),
                        (float)(center.Y + centerSide.Y * Math.Sin(angle)));

                    angle += vertex;
                }

                return result;
            }
        }
    }
}
