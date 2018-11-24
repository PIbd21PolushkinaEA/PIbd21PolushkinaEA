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
    public partial class FormTruckConfig : Form
    {
        /// <summary>
        /// Переменная-выбранная машина
        /// </summary>
        ITransport truck = null;
        /// <summary>
        /// Событие
        /// </summary>
        private event truckDelegate eventAddTruck;
        public FormTruckConfig()
        {
            InitializeComponent();
            panelBlack.MouseDown += panelColor_MouseDown;
            panelGold.MouseDown += panelColor_MouseDown;
            panelGray.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelRed.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
            panelYellow.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
        }
        /// <summary>
        /// Отрисовать машину
        /// </summary>
        private void DrawCar()
        {
            if (truck != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxTruck.Width, pictureBoxTruck.Height);
                Graphics gr = Graphics.FromImage(bmp);
                truck.SetPosition(5, 10, pictureBoxTruck.Width, pictureBoxTruck.Height);
                truck.DrawTruckTrailer(gr);
                pictureBoxTruck.Image = bmp;
            }
        }

        /// <summary>
        /// Добавление события
        /// </summary>
        /// <param name="ev"></param>
        public void AddEvent(truckDelegate ev)
        {
            if (eventAddTruck == null)
            {
                eventAddTruck = new truckDelegate(ev);
            }
            else
            {
                eventAddTruck += ev;
            }
        }
        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTruck_MouseDown(object sender, MouseEventArgs e)
        {
            labelTruck.DoDragDrop(labelTruck.Text, DragDropEffects.Move |
           DragDropEffects.Copy);
        }

        /// <summary>
        /// Передаем информацию при нажатии на Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelTruckTrailer_MouseDown(object sender, MouseEventArgs e)
        {
            labelTruckTrailer.DoDragDrop(labelTruckTrailer.Text, DragDropEffects.Move |
            DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTruck_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Действия при приеме перетаскиваемой информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTruck_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычный грузовик":
                    truck = new Truck(100, 500, Color.White);
                    break;
                case "Грузовик-полуприцеп":
                    truck = new TruckTrailer(100, 500, Color.White, Color.Black, true);
                    break;
            }
            DrawCar();
        }
        /// <summary>
        /// Отправляем цвет с панели
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor,
           DragDropEffects.Move | DragDropEffects.Copy);
        }
        /// <summary>
        /// Проверка получаемой информации (ее типа на соответствие требуемому)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBaseColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// Принимаем основной цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelBaseColor_DragDrop(object sender, DragEventArgs e)
        {
            if (truck != null)
            {
                truck.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawCar();
            }
        }
        /// <summary>
        /// Принимаем дополнительный цвет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if (truck != null)
            {
                if (truck is TruckTrailer)
                {
                    (truck as TruckTrailer).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawCar();
                }
            }
        }
        /// <summary>
        /// Добавление машины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            eventAddTruck?.Invoke(truck);
            Close();
        }


    }
}
