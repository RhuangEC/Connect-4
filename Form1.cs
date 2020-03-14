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
        Game currentGame = new Game();
        int counter;
        int[,] board = new int[7, 6];
        Boolean clickable = false;
        Boolean[] FullRow = new Boolean[7];
        string firstPlayer;
        string secondPlayer;
        Boolean gameStarted = true;


        public Form1()
        {
            InitializeComponent();

            Player1Image = pictureBox1.Image;
            Player2Image = pictureBox2.Image;

            PlayerTurn[0] = Player1Image;
            PlayerTurn[1] = Player2Image;

            BoxArray[0, 0] = pictureBox9;
            BoxArray[0, 1] = pictureBox8;
            BoxArray[0, 2] = pictureBox7;
            BoxArray[0, 3] = pictureBox6;
            BoxArray[0, 4] = pictureBox5;
            BoxArray[0, 5] = pictureBox4;
            BoxArray[1, 0] = pictureBox16;
            BoxArray[1, 1] = pictureBox15;
            BoxArray[1, 2] = pictureBox14;
            BoxArray[1, 3] = pictureBox13;
            BoxArray[1, 4] = pictureBox12;
            BoxArray[1, 5] = pictureBox11;
            BoxArray[2, 0] = pictureBox23;
            BoxArray[2, 1] = pictureBox22;
            BoxArray[2, 2] = pictureBox21;
            BoxArray[2, 3] = pictureBox20;
            BoxArray[2, 4] = pictureBox19;
            BoxArray[2, 5] = pictureBox18;
            BoxArray[3, 0] = pictureBox30;
            BoxArray[3, 1] = pictureBox29;
            BoxArray[3, 2] = pictureBox28;
            BoxArray[3, 3] = pictureBox27;
            BoxArray[3, 4] = pictureBox26;
            BoxArray[3, 5] = pictureBox25;
            BoxArray[4, 0] = pictureBox37;
            BoxArray[4, 1] = pictureBox36;
            BoxArray[4, 2] = pictureBox35;
            BoxArray[4, 3] = pictureBox34;
            BoxArray[4, 4] = pictureBox33;
            BoxArray[4, 5] = pictureBox32;
            BoxArray[5, 0] = pictureBox44;
            BoxArray[5, 1] = pictureBox43;
            BoxArray[5, 2] = pictureBox42;
            BoxArray[5, 3] = pictureBox41;
            BoxArray[5, 4] = pictureBox40;
            BoxArray[5, 5] = pictureBox39;
            BoxArray[6, 0] = pictureBox51;
            BoxArray[6, 1] = pictureBox50;
            BoxArray[6, 2] = pictureBox49;
            BoxArray[6, 3] = pictureBox48;
            BoxArray[6, 4] = pictureBox47;
            BoxArray[6, 5] = pictureBox46;

            Top[0] = pictureBox3;
            Top[1] = pictureBox10;
            Top[2] = pictureBox17;
            Top[3] = pictureBox24;
            Top[4] = pictureBox31;
            Top[5] = pictureBox38;
            Top[6] = pictureBox45;

           

            CurrentPlayerImage = Player1Image;

            UpdateBoxes();

          
            foreach (PictureBox p in Top)
            {
                
                 p.MouseEnter += new EventHandler(EnterButton);
                 p.MouseLeave += new EventHandler(LeaveButton);
                 p.MouseClick += new MouseEventHandler(MakeMove);
                
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
                }
            }

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (BoxArray[x, y].Image == null)
                    {
                        NextBox[x] = BoxArray[x, y];
                        break;
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
                        break;
                    }
                    if(BoxArray[x,5].Image != null)
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
            currentGame.updateboard(board);

        }

        public void ResetBoard()
        {
            board = currentGame.resetBoard();
            UpdateBoxes();
            CurrentPlayerImage = Player1Image;
            counter = 0;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {

            currentGame = new Game();
            gameStarted = true;
            firstPlayer = "human";
            secondPlayer = "human";
            ResetBoard();
            StartGame();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentGame = new Game();
            gameStarted = true;
            firstPlayer = "human";
            secondPlayer = "AI";
            ResetBoard();
            StartGame();

        }
        public void StartGame()
        {
            currentGame.SetGameType("normal", firstPlayer, secondPlayer);
            currentGame.CreatePlayers();
            clickable = true;
            ToggleBoxes();

        }

        public void ToggleBoxes()
        {
            if(clickable == false)
            {
                foreach(PictureBox p in Top)
                {
                    p.Visible = false;
                }
            }
            else
            {
                foreach (PictureBox p in Top)
                {
                    p.Visible = true;
                }
            }
        }
        public void Nextmove()
        {
            EndOfTurn();
            if (gameStarted) 
            {
                AIMove();
                
            }
        }

        public void AIMove()
        {
            if (currentGame.IsHumanMove() == false && gameStarted)
            {
                currentGame.MakeMove();
                counter++;
                CurrentPlayerImage = PlayerTurn[counter % 2];
                UpdateBoxes();
                if(gameStarted == true)
                {
                    Nextmove();
                }

            }

        }
        public void EndOfTurn()
        {
            
            currentGame.EndOfTurn();
            clickable = currentGame.clickable();
            ToggleBoxes();
            if (currentGame.GameEnded() == true)
            {
                MessageBox.Show(currentGame.Outcome());
                gameStarted = false;
                ResetBoard();
                
            }
            
        }

        public Boolean IsRowFull(int x)
        {

            if (BoxArray[x, 5].Image != null)
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

            if (clickable && IsRowFull(index) == false)
            {
                NextBox[index].Image = CurrentPlayerImage;
                UpdateAfterHuman();
                counter++;
                CurrentPlayerImage = PlayerTurn[counter % 2];
                p.Image = CurrentPlayerImage;
            }
            
            Nextmove();

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

            Game currentGame = new Game();



        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {

        }
    } 
       
}
