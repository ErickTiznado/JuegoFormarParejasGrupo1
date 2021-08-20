using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoFormarParejas
{
    //Oscar Manuel Lopez Velasquez

    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        Random random = new Random();
        List<string> iconos = new List<string>()
    {
        "L", "L", "N", "N", "Y", "Y", "Ñ", "Ñ",
        "b", "b", "e", "e", "w", "w", "E", "E"
    };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }

        private void AssignIconsToSquares()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    iconLabel.ForeColor = iconLabel.BackColor;
                    int randomNumber = random.Next(iconos.Count);
                    iconLabel.Text = iconos[randomNumber];

                    iconos.RemoveAt(randomNumber);
                }
            }
        }

        private void label_Click(object sender, EventArgs e)
        {

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
if (timer1.Enabled == true)
        return;


    if (clickedLabel != null)
    {

        if (clickedLabel.ForeColor == Color.Black)
            return;

        if (firstClicked == null)
        {
            firstClicked = clickedLabel;
            firstClicked.ForeColor = Color.Black;
            return;
        }


        secondClicked = clickedLabel;
        secondClicked.ForeColor = Color.Black;

                    CheckForWinner();

                    if (firstClicked.Text == secondClicked.Text)
                    {
                        firstClicked = null;
                        secondClicked = null;
                        return;
                    }

                    timer1.Start();
    }
            }
        }

            private void timer1_Tick(object sender, EventArgs e)
            {
               
                timer1.Stop();

                 firstClicked.ForeColor = firstClicked.BackColor;
                secondClicked.ForeColor = secondClicked.BackColor;


                firstClicked = null;
                secondClicked = null;
            }

        private void CheckForWinner()
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }


            MessageBox.Show("Has encontrado todas las parejas", "Felicidades");
            Close();
        }

    }
}
