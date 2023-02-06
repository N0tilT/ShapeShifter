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
        bool drawable = false;
        private Point PreviousPoint = MousePosition;
        private bool _doMouseDraw;
        private Shape _selectedFigure;

        /// <summary>
        /// Инициализация формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            Canvas.Image = new Bitmap(Canvas.Width, Canvas.Height);
        }

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Массив всех доступных фигур
        /// </summary>
        private readonly Shape[] _shapes = new Shape[]
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
            if (!drawable) return;

            // Сглаживание
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            PointF location = new PointF(50, 50);
            SizeF size = new SizeF(200, 300);

            Shape shape = _shapes[1];
            shape.Location = location;
            shape.Size = size;
            shape.Color = Color.Blue;
            shape.OutlineColor= Color.Black;

            DrawShape(e.Graphics, shape);
            DrawBoundingBox(e.Graphics, shape);

        }

        /// <summary>
        /// Получить случайную фигуру
        /// </summary>
        /// <param name="location">Позиция</param>
        /// <param name="size">Размер</param>
        /// <returns>Случайная фигура</returns>
        private Shape RandomShape(PointF location, SizeF size)
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
            GraphicsPath path = shape.GraphicsPath;

            using (Pen pen = new Pen(shape.OutlineColor, shape.OutlineWidth))
            using (SolidBrush brush = new SolidBrush(shape.Color))
            {
                graphics.FillPath(brush, path);
                graphics.DrawPath(pen, path);
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
                
                graphics.DrawRectangles(pen, new RectangleF[] { shape.BoundingBox });
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

        private void button1_Click(object sender, EventArgs e)
        {
            PointF location = new PointF(50, 50);
            SizeF size = new SizeF(200, 300);
            Shape shape = RandomShape(location, size);


            drawable = true;

            Canvas.Refresh();
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            Canvas.Invalidate();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Point cursorPosition = new Point(MousePosition.X - this.Location.X - 8, MousePosition.Y - this.Location.Y - 30);
            if (e.Button == MouseButtons.Left && _doMouseDraw)
            {
                Pen blackPen = new Pen(Color.Black, 1);
                Graphics g = Graphics.FromImage(Canvas.Image);


                g.DrawLine(blackPen, PreviousPoint, cursorPosition);


                blackPen.Dispose();
                g.Dispose();

                Canvas.Invalidate();
            }

            PreviousPoint = cursorPosition;
        }


        private void toolStripMouseDraw_Click(object sender, EventArgs e)
        {
            _doMouseDraw = !_doMouseDraw;
            _selectedFigure = null;
        }

        private void toolStripFigures_Click(object sender, EventArgs e)
        {
            _doMouseDraw = false;
        }

        private void прямоугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedFigure = _shapes[3];
        }

        private void Canvas_Click(object sender, EventArgs e)
        {
            if (_selectedFigure == null) 
                return;

            Point cursorPosition = new Point(MousePosition.X - this.Location.X - 8, MousePosition.Y - this.Location.Y - 30);
            Graphics graphics = Graphics.FromImage(Canvas.Image);

            Shape shape = _selectedFigure;
            shape.Location = cursorPosition;
            shape.Size = new SizeF(100,200);
            shape.Color = Color.Blue;
            shape.OutlineColor = Color.Black;
            GraphicsPath path = _selectedFigure.GraphicsPath;

            using (Pen pen = new Pen(_selectedFigure.OutlineColor, _selectedFigure.OutlineWidth))
            using (SolidBrush brush = new SolidBrush(_selectedFigure.Color))
            {
                graphics.FillPath(brush, path);
                graphics.DrawPath(pen, path);
            }

            graphics.Dispose();

            Canvas.Invalidate();
        }
    }
}
