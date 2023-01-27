using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapeShifter.View
{
    /// <summary>
    /// Вообще не шарю как тут что
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            // Сглаживание
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            Point location = new Point();

            Shape[] shapes = new Shape[]
            {
                new ArrowShape(location),
                // TODO: Зачем круг если есть настраиваемый эллипс?
                new CircleShape(location),
                new EllipseShape(location),
                new RectangleShape(location),
                // TODO: Зачем квадрат если есть настраиваемый прямоугольник?
                new SquareShape(location),
                new TrapezoidShape(location),
                // TODO: Более "правильный" треугольник  по сравнению с полигональным вариантом,
                //       но так ли это критично?
                new TriangleShape(location),
                new PolygonalShape(location, 3),
                new PolygonalShape(location, 4),
                new PolygonalShape(location, 5),
                new PolygonalShape(location, 6),
                new PolygonalShape(location, 7),
                new PolygonalShape(location, 8)
                // TODO: Добавить звезды? Очень потно.
                //       Генерация по типу полигонов, но есть один нюанс.
            };

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                Shape shape = shapes[random.Next(shapes.Length)];

                shape.Location = new Point(location.X);
                shape.Size = new Size(100, 300);
                shape.Color = Color.Aqua;
                shape.ColorOutline = Color.Black;

                // Вывод на холст
                using (Pen shapePen = new Pen(shape.ColorOutline, 3))
                using (SolidBrush shapeBr = new SolidBrush(shape.Color))
                {
                    e.Graphics.FillPath(shapeBr, shape.GraphicsPath);
                    e.Graphics.DrawPath(shapePen, shape.GraphicsPath);
                }

                // Смещение
                location.X += 150;
            }
        }
    }
}
