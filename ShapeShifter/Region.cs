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
        private Point _location;

        /// <summary>
        /// Размер
        /// </summary>
        private Size _size = Size.Empty;

        /// <summary>
        /// Поворот
        /// </summary>
        private float _angle = 0.00f;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        protected Region(Point location)
        {
            Location = location;
        }

        /// <summary>
        /// Доступ к позиции
        /// </summary>
        public Point Location
        {
            get => _location;
            set => _location = value;
        }

        /// <summary>
        /// Доступ к размеру
        /// </summary>
        public virtual Size Size
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
        public Point Center
        {
            get
            {
                Rectangle box = new Rectangle(Location, Size);

                int x = box.X + box.Width / 2;
                int y = box.Y + box.Height / 2;

                return new Point(x, y);
            }
        }

        /// <summary>
        /// Представление границ с учетом поворота в виде структуры прямоугольника,
        /// параллельного осям координат (AABB)
        /// </summary>
        public virtual Rectangle BoundingBox
        {
            get
            {
                Rectangle box = new Rectangle(Location, Size);
                
                Point topLeft     = RotatePoint(new Point(box.X, box.Y));
                Point topRight    = RotatePoint(new Point(box.Right, box.Y));
                Point bottomLeft  = RotatePoint(new Point(box.X, box.Bottom));
                Point bottomRight = RotatePoint(new Point(box.Right, box.Bottom));

                // Определение границы
                int Left = Math.Min(topLeft.X, Math.Min(topRight.X, Math.Min(bottomLeft.X, bottomRight.X)));
                int Top = Math.Min(topLeft.Y, Math.Min(topRight.Y, Math.Min(bottomLeft.Y, bottomRight.Y)));
                int Right = Math.Max(topLeft.X, Math.Max(topRight.X, Math.Max(bottomLeft.X, bottomRight.X)));
                int Bottom = Math.Max(topLeft.Y, Math.Max(topRight.Y, Math.Max(bottomLeft.Y, bottomRight.Y)));

                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
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
                Rectangle box = new Rectangle(Location, Size);

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
        protected Point RotatePoint(Point point)
        {
            Point center = Center;

            int virtualX = point.X - center.X;
            int virtualY = point.Y - center.Y;

            int resultX = (int)(center.X + Math.Cos(Angle) * virtualX - Math.Sin(Angle) * virtualY);
            int resultY = (int)(center.Y + Math.Sin(Angle) * virtualX + Math.Cos(Angle) * virtualY);

            return new Point(resultX, resultY);
        }
    }
}
