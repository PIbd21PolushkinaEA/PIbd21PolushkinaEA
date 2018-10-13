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
    public partial class FormTruck : Form
    {
        private Truck truck;
        /// <summary>
        /// Конструктор
        /// </summary>
        public FormTruck()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод отрисовки машины
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxCars.Width, pictureBoxCars.Height);
            Graphics gr = Graphics.FromImage(bmp);
            truck.DrawCar(gr);
            pictureBoxCars.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Создать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            truck = new Truck(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue,
           Color.Yellow, true, true, true);
            truck.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxCars.Width,
           pictureBoxCars.Height);
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
                    truck.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    truck.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    truck.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    truck.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }

}

