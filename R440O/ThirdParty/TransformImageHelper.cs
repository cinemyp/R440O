namespace R440O.ThirdParty
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Класс предоставляющий методы для трансформирования изображений
    /// </summary>
    public static class TransformImageHelper
    {
        /// <summary>
        /// Уменьшение размера изображения.
        /// </summary>
        /// <param name="oldBitmap">Изображение, которое необходимо изменить.</param>
        /// <param name="sizePercent">Процентное изменение размера изображения.</param>
        /// <returns>Новое изображение, после изменения.</returns>
        public static Bitmap Scale(Image oldBitmap, int sizePercent)
        {
            var coefficient = sizePercent * 1.0f / 100;
            var newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
            var graphics = Graphics.FromImage(newBitmap);
            graphics.ScaleTransform(coefficient, coefficient);
            graphics.DrawImage(oldBitmap, new Point(5, 5));
            return newBitmap;
        }

        /// <summary>
        /// Поворот изображения на заданный угол.
        /// </summary>
        /// <param name="oldBitmap">Изображение, которое необходимо изменить.</param>
        /// <param name="angle">Угол, на который необходимо повернуть изображение.</param>
        /// <returns>Новое изображение, после изменения.</returns>
        public static Bitmap RotateImageByAngle(Image oldBitmap, float angle)
        {
            var newBitmap = new Bitmap(oldBitmap.Width, oldBitmap.Height);
            var graphics = Graphics.FromImage(newBitmap);
            graphics.TranslateTransform((float)oldBitmap.Width / 2, (float)oldBitmap.Height / 2);
            graphics.RotateTransform(angle);
            graphics.TranslateTransform(-(float)oldBitmap.Width / 2, -(float)oldBitmap.Height / 2);
            graphics.DrawImage(oldBitmap, new Point(0, 0));
            return newBitmap;
        }

        /// <summary>
        /// Вычисление угла, на который необходимо повернуть изображение в соответствии с положением указателя мыши.
        /// </summary>
        /// <param name="elementWidth">Ширина элемента управления.</param>
        /// <param name="elementHeight">Высота элемента управления.</param>
        /// <param name="eventArgs">Положение указателя мыши на элементе управления.</param>
        /// <returns>Угол между вертикалью и положением указателя мыши.</returns>
        public static int CalculateAngle(int elementWidth, int elementHeight, MouseEventArgs eventArgs)
        {
            var centerX = elementWidth / 2;
            var centerY = elementHeight / 2;
            var topX = elementWidth / 2;
            const int topY = 0;
            var pointX = eventArgs.X;
            var pointY = eventArgs.Y;

            var c = Math.Sqrt((Math.Pow(centerX - pointX, 2) + Math.Pow(centerY - pointY, 2)));
            var b = Math.Sqrt((Math.Pow(pointX - topX, 2) + Math.Pow(pointY - topY, 2)));
            var a = Math.Sqrt((Math.Pow(topX - centerX, 2) + Math.Pow(topY - centerY, 2)));
            var cosB = (a * a + c * c - b * b) / (2 * a * c);
            var angle = Math.Acos(cosB) * 180 / Math.PI;
            if (pointX < centerX) angle = -angle;
            return (int)angle;
        }
    }
}
