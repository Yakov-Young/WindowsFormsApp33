using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp33
{
    public partial class Form1 : Form
    {
        new Points A = new Points() 
        { 
            points = { new Point(1, 1, 1), new Point(2, 1, 1), new Point(3, 1, 1),
                                                new Point(4, 1, 1), new Point(5, 1, 1), new Point(6, 1, 1), 
                                                new Point(7, 1, 1),new Point(8, 1, 1),} 
        };
        new Points B = new Points()
        {
            points = { new Point(2, 1, 1), new Point(4, 1, 1), new Point(6, 1, 1),
                                                new Point(8, 1, 1),}
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxX.Text = "1";
            textBoxY.Text = "1";
            textBoxZ.Text = "1";
            comboBox1.SelectedIndex = 0;

            foreach (var item in this.Controls) //обходим все элементы формы
            {
                if (item is TextBox) // проверяем, что это кнопка
                {
                    ((TextBox)item).Leave += TextBoxVisor; //приводим к типу и устанавливаем обработчик события  
                }
            }
        }

        private void TextBoxVisor(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            double ad;
            try
            {
                if (!Double.TryParse(textBox.Text, out ad))
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                textBox.Text = "0";
                MessageBox.Show("Неверное значение", "Error");
            }
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Point point = new Point(Convert.ToDouble(textBoxX.Text), Convert.ToDouble(textBoxY.Text), Convert.ToDouble(textBoxZ.Text));
            int item = comboBox1.SelectedIndex;

            richTextBox1.Clear();
            
            if (item == 0)
            {
                A += point;
                Points.Get(A, richTextBox1);
            }
            else if (item == 1)
            {
                B += point;
                Points.Get(B, richTextBox1);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Point point = new Point(Convert.ToDouble(textBoxX.Text), Convert.ToDouble(textBoxY.Text), Convert.ToDouble(textBoxZ.Text));
            int item = comboBox1.SelectedIndex;

            richTextBox1.Clear();

            if (item == 0)
            {
                A -= point;
                Points.Get(A, richTextBox1);
            }
            else if (item == 1)
            {
                B -= point;
                Points.Get(B, richTextBox1);
            }
        }

        private void buttonEqv_Click(object sender, EventArgs e)
        {
            if (A == B)
            {
                if (A.points.Count == 0 || B.points.Count == 0)
                {
                    MessageBox.Show("Проверьте введены ли значения в массивы", "Ошибка");
                }
                else
                {
                    MessageBox.Show("Массивы равны", "Результат");
                }
            }
            else
            {
                if (A.points.Count != B.points.Count)
                {

                }
                else
                {
                    MessageBox.Show("Массивы не равны", "Результат");
                }
            }
        }

        private void buttonAddArr_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            richTextBox1.Clear();
            Points.Get(A + B, richTextBox1);
        }

        private void buttonRemoveArr_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            richTextBox1.Clear();
            Points.Get(A - B, richTextBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                Points.Get(A, richTextBox1);
            }
            else
            {
                Points.Get(B, richTextBox1);
            }
        }
    }
}
