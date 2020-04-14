using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class SnakeForm : Form
    {
        SnakeLogic mySnakeLogic;
        const int fieldSize = 30;
        Graphics graphics;
        public SnakeForm()
        {
            InitializeComponent();
            mySnakeLogic = new SnakeLogic(20,15);
            mySnakeLogic.SnakeMoved += MySnakeLogic_SnakeMoved;

            pictureBoxSnakeBoard.Image = new Bitmap(mySnakeLogic.Width * fieldSize + 1,
                                                    mySnakeLogic.Height * fieldSize + 1);
            graphics = Graphics.FromImage(pictureBoxSnakeBoard.Image);

            RepaintBoard();
        }

        private void MySnakeLogic_SnakeMoved()
        {
            RepaintBoard();
        }

        private void RepaintBoard()
        {
            graphics.Clear(Color.LightGreen);
            for(int x=0; x<mySnakeLogic.Width; x++)
            {
                for(int y=0; y<mySnakeLogic.Height; y++)
                {
                    graphics.DrawRectangle(new Pen(Color.Green), x * fieldSize, y * fieldSize, fieldSize, fieldSize);
                }
            }
            for (int i = 0; i < mySnakeLogic.Snake.Count; i++)
            {
                graphics.FillEllipse(new SolidBrush(Color.GreenYellow), mySnakeLogic.Snake[i].X * fieldSize,
                    mySnakeLogic.Snake[i].Y * fieldSize,
                    fieldSize, fieldSize);
            }
            pictureBoxSnakeBoard.Refresh();
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
