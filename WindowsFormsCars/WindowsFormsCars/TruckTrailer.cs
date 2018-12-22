using System;
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
    public class TruckTrailer : Truck, IComparable<TruckTrailer>, IEquatable<TruckTrailer>
    {
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }
        /// <summary>
        /// Признак наличия кабины
        /// </summary>
        public bool Сabin { private set; get; }

        /// Конструктор
        public TruckTrailer(int maxSpeed, float weight, Color mainColor, Color dopColor, bool
       cabin) : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Сabin = cabin;
        }

        /// Конструктор
        public TruckTrailer(string info) : base(info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 5)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
                DopColor = Color.FromName(strs[3]);
                Сabin = Convert.ToBoolean(strs[4]);
            }
        }
        /// <summary>
        /// Отрисовка автомобиля
        /// </summary>
        /// <param name="g"></param>
        public override void DrawTruckTrailer(Graphics g)
        {
            if (Сabin)
            {
                Brush cabindop = new SolidBrush(DopColor);//прицеп
                g.FillRectangle(cabindop, _startPosX + 35, _startPosY - 4, 72, 50);
            }

            Brush br = new SolidBrush(MainColor);//кабина
            g.FillRectangle(br, _startPosX - 3, _startPosY + 10, 35, 38);
            g.FillRectangle(br, _startPosX + 30, _startPosY + 43, 30, 5);

            Brush brBlack = new SolidBrush(Color.Black);//колеса
            g.FillEllipse(brBlack, _startPosX + 83, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 70, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 40, _startPosY + 40, 17, 17);
            g.FillEllipse(brBlack, _startPosX + 7, _startPosY + 40, 17, 17);

            Brush brBlue = new SolidBrush(Color.LightBlue);//окно
            g.FillRectangle(brBlue, _startPosX + 5, _startPosY + 15, 20, 15);

        }
        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }
        public override string ToString()
        {
            return base.ToString() + ";" + DopColor.Name + ";" + Сabin;
        }
        /// <summary>
        /// Метод интерфейса IComparable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TruckTrailer other)
        {
            var res = (this is Truck).CompareTo(other is Truck);
            if (res != 0)
            {
                return res;
            }
            if (DopColor != other.DopColor)
            {
                DopColor.Name.CompareTo(other.DopColor.Name);
            }
            if (Сabin != other.Сabin)
            {
                return Сabin.CompareTo(other.Сabin);
            }

            return 0;
        }
        /// <summary>
        /// Метод интерфейса IEquatable для класса SportCar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(TruckTrailer other)
        {
            var res = (this as Truck).Equals(other as Truck);
            if (!res)
            {
                return res;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (DopColor != other.DopColor)
            {
                return false;
            }
            if (Сabin != other.Сabin)
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            TruckTrailer carObj = obj as TruckTrailer;
            if (carObj == null)
            {
                return false;
            }
            else
            {
                return Equals(carObj);
            }
        }
        /// <summary>
        /// Перегрузка метода от object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
