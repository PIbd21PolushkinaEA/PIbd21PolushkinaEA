﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    /// <summary>
    /// Класс отрисовки автомобиля
    /// </summary>
    public class TruckTrailer : Truck
    {
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия кабины
        /// </summary>
        public bool Сabin { private set; get; }

        /// Конструктор
        /// </summary>
        /// <param name="maxSpeed">Максимальная скорость</param>
        /// <param name="weight">Вес автомобиля</param>
        /// <param name="mainColor">Основной цвет кузова</param>
        /// <param name="dopColor">Дополнительный цвет</param>
        /// <param name="frontSpoiler">Признак наличия переднего спойлера</param>
        /// <param name="sideSpoiler">Признак наличия боковых спойлеров</param>
        /// <param name="backSpoiler">Признак наличия заднего спойлера</param>
        public TruckTrailer(int maxSpeed, float weight, Color mainColor, Color dopColor, bool
       cabin) : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Сabin = cabin;
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTruckTrailer(Graphics g)
        {
            Brush spoiler = new SolidBrush(MainColor);//прицеп
            g.FillRectangle(spoiler, _startPosX + 35, _startPosY - 4, 72, 50);

            Brush brRed = new SolidBrush(DopColor);//кабина
            g.FillRectangle(brRed, _startPosX - 3, _startPosY + 10, 35, 38);
            g.FillRectangle(brRed, _startPosX + 30, _startPosY + 43, 30, 5);

            Brush brBlack = new SolidBrush(Color.Black);//колеса
            g.FillEllipse(brBlack, _startPosX + 83, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 70, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 40, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 7, _startPosY + 40, 17, 17);

            Brush brBlue = new SolidBrush(Color.LightBlue);//окно
            g.FillRectangle(brBlue, _startPosX + 5, _startPosY + 15, 20, 15);


        }
    }
}
