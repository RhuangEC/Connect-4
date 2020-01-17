using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect_4
{
    public partial class Form1 : Form
    {

        PictureBox[,] BoxArray = new PictureBox[7, 7];
        Image Player1Image;
        Image Player2Image;
        Image[] PlayerTurn = new Image[2];

        public Form1()
        {
            InitializeComponent();

            Player1Image = pictureBox1.Image;
            Player2Image = pictureBox2.Image;

            PlayerTurn[0] = Player1Image;
            PlayerTurn[1] = Player2Image;

            BoxArray[0, 0] = pictureBox3;
            BoxArray[0, 1] = pictureBox4;
            BoxArray[0, 2] = pictureBox5;
            BoxArray[0, 3] = pictureBox6;
            BoxArray[0, 4] = pictureBox7;
            BoxArray[0, 5] = pictureBox8;
            BoxArray[0, 6] = pictureBox9;
            BoxArray[1, 0] = pictureBox10;
            BoxArray[1, 1] = pictureBox11;
            BoxArray[1, 2] = pictureBox12;
            BoxArray[1, 3] = pictureBox13;
            BoxArray[1, 4] = pictureBox14;
            BoxArray[1, 5] = pictureBox15;
            BoxArray[1, 6] = pictureBox16;
            BoxArray[2, 0] = pictureBox17;
            BoxArray[2, 1] = pictureBox18;
            BoxArray[2, 2] = pictureBox19;
            BoxArray[2, 3] = pictureBox20;
            BoxArray[2, 4] = pictureBox21;
            BoxArray[2, 5] = pictureBox22;
            BoxArray[2, 6] = pictureBox23;
            BoxArray[3, 0] = pictureBox24;
            BoxArray[3, 1] = pictureBox25;
            BoxArray[3, 2] = pictureBox26;
            BoxArray[3, 3] = pictureBox27;
            BoxArray[3, 4] = pictureBox28;
            BoxArray[3, 5] = pictureBox29;
            BoxArray[3, 6] = pictureBox30;
            BoxArray[4, 0] = pictureBox31;
            BoxArray[4, 1] = pictureBox32;
            BoxArray[4, 2] = pictureBox33;
            BoxArray[4, 3] = pictureBox34;
            BoxArray[4, 4] = pictureBox35;
            BoxArray[4, 5] = pictureBox36;
            BoxArray[4, 6] = pictureBox37;
            BoxArray[5, 0] = pictureBox38;
            BoxArray[5, 1] = pictureBox39;
            BoxArray[5, 2] = pictureBox40;
            BoxArray[5, 3] = pictureBox41;
            BoxArray[5, 4] = pictureBox42;
            BoxArray[5, 5] = pictureBox43;
            BoxArray[5, 6] = pictureBox44;
            BoxArray[6, 0] = pictureBox45;
            BoxArray[6, 1] = pictureBox46;
            BoxArray[6, 2] = pictureBox47;
            BoxArray[6, 3] = pictureBox48;
            BoxArray[6, 4] = pictureBox49;
            BoxArray[6, 5] = pictureBox50;
            BoxArray[6, 6] = pictureBox51;



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        { 

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {

            int counter = 0;

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 7; y++)
                {

                    BoxArray[x, y].Image = PlayerTurn[counter % 2];

                    counter++;

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {



        }
    
    } 
       
}
