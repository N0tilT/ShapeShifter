using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ShapeShifter
{
    /// <summary>
    /// Прямоугольный регион
    /// </summary>
    public abstract class Region
    {
        /// <summary>
        /// Позиция (верхний левый угол исходного положения)
        /// </summary>
        private PointF _location;

        /// <summary>
        /// Размер
        /// </summary>
        private SizeF _size = SizeF.Empty;

        /// <summary>
        /// Поворот
        /// </summary>
        private float _angle = 0.00f;

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        protected Region()
        {
            Location = new PointF();
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        protected Region(PointF location)
        {
            Location = location;
        }

        /// <summary>
        /// Доступ к позиции
        /// </summary>
        public PointF Location
        {
            get => _location;
            set => _location = value;
        }

        /// <summary>
        /// Доступ к размеру
        /// </summary>
        public virtual SizeF Size
        {
            get => _size;
            set => _size = value;
        }

        /// <summary>
        /// Доступ к повороту
        /// </summary>
        public float Angle
        {
            get => _angle;
            set => _angle = value;
        }

        /// <summary>
        /// Центр
        /// </summary>
        public PointF Center
        {
            get
            {
                RectangleF box = new RectangleF(Location, Size);

                float x = box.X + box.Width / 2;
                float y = box.Y + box.Height / 2;

                return new PointF(x, y);
            }
        }

        /// <summary>
        /// Представление границ с учетом поворота в виде структуры прямоугольника,
        /// параллельного осям координат (AABB)
        /// </summary>
        public virtual RectangleF BoundingBox
        {
            get
            {
                RectangleF box = new RectangleF(Location, Size);
                
                PointF topLeft     = RotatePoint(new PointF(box.X, box.Y));
                PointF topRight    = RotatePoint(new PointF(box.Right, box.Y));
                PointF bottomLeft  = RotatePoint(new PointF(box.X, box.Bottom));
                PointF bottomRight = RotatePoint(new PointF(box.Right, box.Bottom));

                // Определение границы
                float Left = Math.Min(topLeft.X, Math.Min(topRight.X, Math.Min(bottomLeft.X, bottomRight.X)));
                float Top = Math.Min(topLeft.Y, Math.Min(topRight.Y, Math.Min(bottomLeft.Y, bottomRight.Y)));
                float Right = Math.Max(topLeft.X, Math.Max(topRight.X, Math.Max(bottomLeft.X, bottomRight.X)));
                float Bottom = Math.Max(topLeft.Y, Math.Max(topRight.Y, Math.Max(bottomLeft.Y, bottomRight.Y)));

                return RectangleF.FromLTRB(Left, Top, Right, Bottom);
            }
        }

        /// <summary>
        /// Порядок графического построения
        /// </summary>
        public virtual GraphicsPath GraphicsPath
        {
            get
            {
                GraphicsPath path = new GraphicsPath();

                path.AddPolygon(ShapePoints);

                return path;
            }
        }

        /// <summary>
        /// Представление в виде массива точек в порядке построения
        /// </summary>
        /// <returns></returns>
        protected virtual PointF[] ShapePoints
        {
            get
            {
                RectangleF box = new RectangleF(Location, Size);

                PointF[] result = new PointF[]
                {
                    new PointF(box.Left, box.Top),
                    new PointF(box.Right, box.Top),
                    new PointF(box.Right, box.Bottom),
                    new PointF(box.Left, box.Bottom)
                };

                return result;
            }
        }

        /// <summary>
        /// Повернуть точку относительно центра региона
        /// </summary>
        /// <param name="point">Исходное положение</param>
        /// <returns>Новая точка со смещенными координатами</returns>
        protected PointF RotatePoint(PointF point)
        {
            PointF center = Center;

            float virtualX = point.X - center.X;
            float virtualY = point.Y - center.Y;

            float resultX = (float)(center.X + Math.Cos(Angle) * virtualX - Math.Sin(Angle) * virtualY);
            float resultY = (float)(center.Y + Math.Sin(Angle) * virtualX + Math.Cos(Angle) * virtualY);

            return new PointF(resultX, resultY);
        }
    }
}
