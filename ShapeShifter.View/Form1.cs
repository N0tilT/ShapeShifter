using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShapeShifter.View
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Массив всех доступных фигур
        /// </summary>
        private Shape[] _shapes = new Shape[]
        {
            new ArrowShape(),
            new CircleShape(), // TODO: Зачем круг если есть настраиваемый эллипс?
            new EllipseShape(),
            new RectangleShape(),
            new SquareShape(), // TODO: Зачем квадрат если есть настраиваемый прямоугольник?
            new TrapezoidShape(),
            new TriangleShape(), // TODO: Более "правильный" треугольник  по сравнению с полигональным вариантом.
            new PolygonalShape(3),
            new PolygonalShape(4),
            new PolygonalShape(5),
            new PolygonalShape(6),
            new PolygonalShape(7),
            new PolygonalShape(8)
        };

        /// <summary>
        /// Перерисовка холста
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Событие перерисовки</param>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // Сглаживание
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            Point location = new Point();
            Size size = new Size(200, 300);

            for (int i = 0; i < 5; i++)
            {
                Shape shape = RandomShape(location, size);

                DrawShape(e.Graphics, shape);
                DrawBoundingBox(e.Graphics, shape);

                // Смещение для следующей фигуры
                location.X += 250;
            }
        }

        /// <summary>
        /// Получить случайную фигуру
        /// </summary>
        /// <param name="location">Позиция</param>
        /// <param name="size">Размер</param>
        /// <returns>Случайная фигура</returns>
        private Shape RandomShape(Point location, Size size)
        {
            Shape shape = _shapes[_random.Next(_shapes.Length)];

            shape.Location = location;
            shape.Size = size;
            shape.Color = RandomColor();
            shape.OutlineColor = Color.Black;

            return shape;
        }

        /// <summary>
        /// Нарисовать фигуру
        /// </summary>
        /// <param name="graphics">Графика</param>
        /// <param name="shape">Фигура</param>
        private void DrawShape(Graphics graphics, Shape shape)
        {
            using (Pen shapePen = new Pen(shape.OutlineColor, shape.OutlineWidth))
            using (SolidBrush shapeBr = new SolidBrush(shape.Color))
            {
                graphics.FillPath(shapeBr, shape.GraphicsPath);
                graphics.DrawPath(shapePen, shape.GraphicsPath);
            }
        }

        /// <summary>
        /// Нарисовать границу вокруг фигуры пунктиром
        /// </summary>
        /// <param name="graphics">Графика</param>
        /// <param name="shape">Фигура</param>
        private void DrawBoundingBox(Graphics graphics, Shape shape)
        {
            using (Pen pen = new Pen(Color.Gray, Shape.DefaultOutlineWidth))
            {
                pen.DashStyle = DashStyle.Dash;
                
                graphics.DrawRectangle(pen, shape.BoundingBox);
            }
        }

        /// <summary>
        /// Получить случайный цвет
        /// </summary>
        /// <returns>Случайный цвет</returns>
        private Color RandomColor()
        {
            return Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256));
        }
    }
}
