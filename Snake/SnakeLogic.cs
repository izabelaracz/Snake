using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class SnakeLogic
    {
        public delegate void SnakeEvent();
        public event SnakeEvent SnakeMoved;
        
        Timer timerSnakeMove = new Timer();
        private int width;
        private int height;
        private List<Point> snake;

        public int Width { get => width; private set => width = value; }
        public int Height { get => height; private set => height = value; }
        public List<Point> Snake { get => snake; private set => snake = value; }

        public SnakeLogic(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            timerSnakeMove.Enabled = true;
            timerSnakeMove.Interval = 500;
            timerSnakeMove.Tick += TimerSnakeMove_Tick;

            Snake = new List<Point>();
            Snake.Add(new Point(width/2, height-1));
            Snake.Add(new Point(width/2, height+0));
            Snake.Add(new Point(width/2, height+1));
            Snake.Add(new Point(width/2, height+2));
        }

        private void TimerSnakeMove_Tick(object sender, EventArgs e)
        {
            Point newHead = new Point(Snake.First().X, Snake.First().Y - 1);
            Snake.Insert(0, newHead);
            Snake.Remove(Snake.Last());
            if (SnakeMoved != null)
            {
                SnakeMoved();
            }
        }
    }
}
