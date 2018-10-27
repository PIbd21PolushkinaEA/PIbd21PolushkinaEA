using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCars
{
    public partial class FormTruckTrailer : Form
    {
        private TruckTrailer trucktrailer;
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormTruckTrailer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод отрисовки машины
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTruck.Width, pictureBoxTruck.Height);
            Graphics gr = Graphics.FromImage(bmp);
            trucktrailer.DrawTruckTrailer(gr);
            pictureBoxTruck.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            trucktrailer = new TruckTrailer(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true);
            trucktrailer.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxTruck.Width,
           pictureBoxTruck.Height);
            Draw();
        }
        /// <summary>
        /// Обработка нажатия кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    trucktrailer.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    trucktrailer.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    trucktrailer.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    trucktrailer.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }

}

