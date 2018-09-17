using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
    /// <summary>
    /// Класс отрисовки автомобиля
    /// </summary>
    public class Truck
    {
        /// <summary>
        /// Левая координата отрисовки автомобиля
        /// </summary>
        private float _startPosX;
        /// <summary>
        /// Правая кооридната отрисовки автомобиля
        /// </summary>
        private float _startPosY;
        /// <summary>
        /// Ширина окна отрисовки
        /// </summary>
        public int _pictureWidth;
        //Высота окна отрисовки
        public int _pictureHeight;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private const int carWidth = 100;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        private const int carHeight = 60;
        /// <summary>
        /// Максимальная скорость
        /// </summary>
        public int MaxSpeed { private set; get; }
        /// <summary>
        /// Вес автомобиля
        /// </summary>
        public float Weight { private set; get; }
        /// <summary>
        /// Основной цвет кузова
        /// </summary>
        public Color MainColor { private set; get; }
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия переднего спойлера
        /// </summary>
        public bool FrontSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия боковых спойлеров
        /// </summary>
        public bool SideSpoiler { private set; get; }
        /// <summary>
        /// Признак наличия заднего спойлера
        /// </summary>
        public bool BackSpoiler { private set; get; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>
        public Truck(int maxSpeed, float weight, Color mainColor, Color dopColor, bool
       frontSpoiler, bool sideSpoiler, bool backSpoiler)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
            FrontSpoiler = frontSpoiler;
            SideSpoiler = sideSpoiler;
            BackSpoiler = backSpoiler;
        }
        /// <summary>
        /// Установка позиции автомобиля
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="y">Координата Y</param>
        /// <param name="width">Ширина картинки</param>
        /// <param name="height">Высота картинки</param>
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        /// <summary>
        /// Изменение направления пермещения
        /// </summary>
        /// <param name="direction">Направление</param>
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                // вправо
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - carWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                //влево
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                //вверх
                case Direction.Up:
                    if (_startPosY - step > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                //вниз
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - carHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public void DrawCar(Graphics g)
        {
            //Brush brBlue2 = new SolidBrush(Color.LightBlue);//поле
            //g.FillRectangle(brBlue2, _startPosX - 5, _startPosY - 6, 106, 62);

            Brush spoiler = new SolidBrush(Color.Gray);//прицеп
            g.FillRectangle(spoiler, _startPosX + 35, _startPosY-4, 72, 50);

            Brush brRed = new SolidBrush(Color.Red);//кабина
            g.FillRectangle(brRed, _startPosX-3, _startPosY +10, 35, 38);
            g.FillRectangle(brRed, _startPosX +30, _startPosY + 43, 30, 5);

            Brush brBlack = new SolidBrush(Color.Black);//колеса
            g.FillEllipse(brBlack, _startPosX + 83, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 70, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 40, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 7, _startPosY + 40, 17, 17);

            Brush brBlue = new SolidBrush(Color.LightBlue);//окно
            g.FillRectangle(brBlue, _startPosX +5, _startPosY +15, 20, 15);

            Brush brGreen = new SolidBrush(Color.Green);//полоски
            g.FillRectangle(brGreen, _startPosX +35, _startPosY + 7, 70, 5);
            g.FillRectangle(brGreen, _startPosX + 35, _startPosY + 15, 70, 5);
        }
    }
}
