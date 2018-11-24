using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    public class Truck : TruckAbstract
    {
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        protected const int carWidth = 100;
        /// <summary>
        /// Ширина отрисовки автомобиля
        /// </summary>
        protected const int carHeight = 60;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        public Truck(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="info">Информация по объекту</param>
        public Truck(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
        }
        public override void MoveTransport(Direction direction)
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
        public override void DrawTruckTrailer(Graphics g)
        {
            Brush br = new SolidBrush(MainColor);//кабина
            g.FillRectangle(br, _startPosX - 3, _startPosY + 10, 35, 38);
            g.FillRectangle(br, _startPosX + 30, _startPosY + 43, 70, 5);

            Brush brBlack = new SolidBrush(Color.Black);//колеса
            g.FillEllipse(brBlack, _startPosX + 83, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 70, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 40, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 7, _startPosY + 40, 17, 17);

            Brush brBlue = new SolidBrush(Color.LightBlue);//окно
            g.FillRectangle(brBlue, _startPosX + 5, _startPosY + 15, 20, 15);
        }
        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + MainColor.Name;
        }

    }
}
