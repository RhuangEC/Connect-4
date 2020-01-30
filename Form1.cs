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

        PictureBox[,] BoxArray = new PictureBox[7, 6];
        PictureBox[] Top = new PictureBox[7];
        PictureBox[] NextBox = new PictureBox[7];
        Image Player1Image;
        Image Player2Image;
        Image CurrentPlayerImage;
        Image[] PlayerTurn = new Image[2];
        int counter;
        int[,] board = new int[7, 6];
        Boolean clickable = true;
        Boolean[] FullRow = new Boolean[7];
        string turn;


        public Form1()
        {
            InitializeComponent();

            Player1Image = pictureBox1.Image;
            Player2Image = pictureBox2.Image;

            PlayerTurn[0] = Player1Image;
            PlayerTurn[1] = Player2Image;

            BoxArray[0, 0] = pictureBox4;
            BoxArray[0, 1] = pictureBox5;
            BoxArray[0, 2] = pictureBox6;
            BoxArray[0, 3] = pictureBox7;
            BoxArray[0, 4] = pictureBox8;
            BoxArray[0, 5] = pictureBox9;
            BoxArray[1, 0] = pictureBox11;
            BoxArray[1, 1] = pictureBox12;
            BoxArray[1, 2] = pictureBox13;
            BoxArray[1, 3] = pictureBox14;
            BoxArray[1, 4] = pictureBox15;
            BoxArray[1, 5] = pictureBox16;
            BoxArray[2, 0] = pictureBox18;
            BoxArray[2, 1] = pictureBox19;
            BoxArray[2, 2] = pictureBox20;
            BoxArray[2, 3] = pictureBox21;
            BoxArray[2, 4] = pictureBox22;
            BoxArray[2, 5] = pictureBox23;
            BoxArray[3, 0] = pictureBox25;
            BoxArray[3, 1] = pictureBox26;
            BoxArray[3, 2] = pictureBox27;
            BoxArray[3, 3] = pictureBox28;
            BoxArray[3, 4] = pictureBox29;
            BoxArray[3, 5] = pictureBox30;
            BoxArray[4, 0] = pictureBox32;
            BoxArray[4, 1] = pictureBox33;
            BoxArray[4, 2] = pictureBox34;
            BoxArray[4, 3] = pictureBox35;
            BoxArray[4, 4] = pictureBox36;
            BoxArray[4, 5] = pictureBox37;
            BoxArray[5, 0] = pictureBox39;
            BoxArray[5, 1] = pictureBox40;
            BoxArray[5, 2] = pictureBox41;
            BoxArray[5, 3] = pictureBox42;
            BoxArray[5, 4] = pictureBox43;
            BoxArray[5, 5] = pictureBox44;
            BoxArray[6, 0] = pictureBox46;
            BoxArray[6, 1] = pictureBox47;
            BoxArray[6, 2] = pictureBox48;
            BoxArray[6, 3] = pictureBox49;
            BoxArray[6, 4] = pictureBox50;
            BoxArray[6, 5] = pictureBox51;

            Top[0] = pictureBox3;
            Top[1] = pictureBox10;
            Top[2] = pictureBox17;
            Top[3] = pictureBox24;
            Top[4] = pictureBox31;
            Top[5] = pictureBox38;
            Top[6] = pictureBox45;

           

            CurrentPlayerImage = Player1Image;

          
            foreach (PictureBox p in Top)
            {
                    UpdateAfterHuman();
                    p.MouseEnter += new EventHandler(EnterButton);
                    p.MouseLeave += new EventHandler(LeaveButton);
                    p.MouseClick += new MouseEventHandler(MakeMove);

            }


            Game newGame = new Game("normal", "AI", "human");

            board = newGame.updateboard();

            if (newGame.LastMove() == "human")
            {

            }
            else
            {
                UpdateBoxes();
            }

            if (newGame.status() == true)
            {
                clickable = false;

                string outcome = newGame.Outcome();

                if (outcome == "WIN")
                {

                }
                else if (outcome == "DRAW")
                {

                }
                else
                {

                }
            }
        }

        public void UpdateBoxes()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {

                    if (board[x, y] == 0)
                    {
                        BoxArray[x, y].Image = null;
                    }
                    else if (board[x, y] == 1)
                    {
                        BoxArray[x, y].Image = Player1Image;
                    }
                    else if (board[x, y] == 2) 
                    {
                        BoxArray[x, y].Image = Player2Image;
                    }

                    if (BoxArray[x, y].Image == null)
                    {
                        NextBox[x] = BoxArray[x, y];

                    }
                    else
                    {
                        FullRow[x] = true;
                    }
                }
            }
        }

        public void UpdateAfterHuman()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (BoxArray[x, y].Image == null)
                    {
                        NextBox[x] = BoxArray[x, y];
                    }
                    else
                    {
                        FullRow[x] = true;
                    }

                    if (BoxArray[x, y].Image == null)
                    {
                        board[x, y] = 0;
                    }
                    else if (BoxArray[x, y].Image == Player1Image)
                    {
                        board[x, y] = 1;
                    }
                    else if (BoxArray[x, y].Image == Player2Image)
                    {
                        board[x, y] = 2;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public Boolean IsRowFull(int x)
        {

            if (BoxArray[x, 0].Image != null)
            {
                return true;
            }

                return false;
        }
     
        public void MakeMove(object sender, EventArgs args)
        {

            PictureBox p = (PictureBox)sender;
            int index;

            index = Array.IndexOf(Top, p);

            if (clickable == true && IsRowFull(index) == false)
            {
                NextBox[index].Image = CurrentPlayerImage;
                UpdateAfterHuman();
                counter++;
                CurrentPlayerImage = PlayerTurn[counter % 2];
                p.Image = CurrentPlayerImage;
            }
        }
        public void EnterButton(Object sender, EventArgs args)
        {
            PictureBox p = (PictureBox)sender;
            p.Image = CurrentPlayerImage;

        }

        public void LeaveButton(object sender, EventArgs args)
        {
            PictureBox p = (PictureBox)sender;
            p.Image = null;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox3_Click(object sender, EventArgs e)
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
                for (int y = 0; y < 6; y++)
                {

                    BoxArray[x, y].Image = PlayerTurn[counter % 2];

                    counter++;

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            clickable = true;
            turn = "human";
        }
    } 
       
}
