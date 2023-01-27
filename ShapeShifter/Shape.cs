using System.Drawing;

namespace ShapeShifter
{
    /// <summary>
    /// Фигура в прямоугольном регионе
    /// </summary>
    public abstract class Shape : Region
    {
        /// <summary>
        /// Цвет заливки
        /// </summary>
        private Color _color = Color.Transparent;

        /// <summary>
        /// Цвет линии
        /// </summary>
        private Color _colorOutline = Color.Transparent;

        /// <summary>
        /// Статус выделения
        /// </summary>
        private bool _isSelected = false;

        /// <summary>
        /// Статус перемещения
        /// </summary>
        private bool _isDragged = false;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="location">Позиция</param>
        protected Shape(Point location) : base(location)
        {
            // PASS
        }

        /// <summary>
        /// Тип
        /// </summary>
        public virtual ShapeType Type => ShapeType.None;

        /// <summary>
        /// Доступ к цвету заливки
        /// </summary>
        public Color Color
        {
            get => _color;
            set => _color = value;
        }

        /// <summary>
        /// Доступ к цвету линии
        /// </summary>
        public Color ColorOutline
        {
            get => _colorOutline;
            set => _colorOutline = value;
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
