using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Фигура в прямоугольном регионе
    /// </summary>
    public abstract class Shape : Region
    {
        /// <summary>
        /// Цвет линии
        /// </summary>
        protected Color _color = Color.Transparent;

        /// <summary>
        /// Цвет заливки
        /// </summary>
        protected Color _colorFill = Color.Transparent;

        /// <summary>
        /// Статус выделения
        /// </summary>
        protected bool _isSelected = false;

        /// <summary>
        /// Статус перемещения
        /// </summary>
        protected bool _isDragged = false;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        protected Shape(Point location) : base(location)
        {
            IsDragged = false;
            IsSelected = false;
        }

        /// <summary>
        /// Тип
        /// </summary>
        public virtual ShapeType Type => ShapeType.None;

        /// <summary>
        /// Доступ к цвету линии
        /// </summary>
        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        /// <summary>
        /// Доступ к цвету заливки
        /// </summary>
        public Color ColorFill
        {
            get => _colorFill;
            set => _colorFill = value;
        }

        /// <summary>
        /// Доступ к статусу выделения
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set => _isSelected = value;
        }

        /// <summary>
        /// Доступ к статусу премещения
        /// </summary>
        public bool IsDragged
        {
            get => _isDragged;
            set => _isDragged = value;
        }
    }
}
