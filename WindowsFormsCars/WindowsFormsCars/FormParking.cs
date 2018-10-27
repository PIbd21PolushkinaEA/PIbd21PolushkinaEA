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
    public partial class FormParking : Form
    {
        /// <summary>
        /// Объект от класса-парковки
        /// </summary>
        Parking<ITransport> parking;
        public FormParking()
        {
            InitializeComponent();
            parking = new Parking<ITransport>(20, pictureBoxParking.Width,
           pictureBoxParking.Height);
            Draw();
        }
        /// <summary>
        /// Метод отрисовки парковки
        /// </summary>
        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxParking.Width, pictureBoxParking.Height);
            Graphics gr = Graphics.FromImage(bmp);
            parking.Draw(gr);
            pictureBoxParking.Image = bmp;
        }
        /// <summary>
        /// Обработка нажатия кнопки "Припарковать автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetTruck_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var truck = new Truck(100, 1000, dialog.Color);
                int place = parking + truck;
                Draw();
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Припарковать гоночный автомобиль"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSetTruckTrailer_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var truck = new TruckTrailer(100, 1000, dialog.Color, dialogDop.Color,
                   true);
                    int place = parking + truck;
                    Draw();
                }
            }
        }
        /// <summary>
        /// Обработка нажатия кнопки "Забрать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakeTruck_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.Text != "")
            {
                var truck = parking - Convert.ToInt32(maskedTextBox.Text);
                if (truck != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeTruck.Width,
                   pictureBoxTakeTruck.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    truck.SetPosition(5, 5, pictureBoxTakeTruck.Width,
                  pictureBoxTakeTruck.Height);
                    truck.DrawTruckTrailer(gr);
                    pictureBoxTakeTruck.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeTruck.Width,
                   pictureBoxTakeTruck.Height);
                    pictureBoxTakeTruck.Image = bmp;
                }
                Draw();
            }
        }
    }
}
