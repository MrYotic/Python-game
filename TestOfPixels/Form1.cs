using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TestOfPixels
{
    public partial class Form1 : Form
    {
        #region Form Move
        public void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                ((Control)sender).Capture = false;
                var m = Message.Create(Handle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
                WndProc(ref m);
            }
        }
        #endregion
        #region DllImport
        [DllImport("User32.dll")] private static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        [DllImport("User32.dll")] private static extern short GetAsyncKeyState(System.Int32 vKey);
        #endregion
        #region Misk
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Controls_MouseDown;
        }
        internal List<int[]> snake = new List<int[]>();
        internal void DrawedPixel(int x, int y, bool state)
        {
            if (x > 20 || y > 20 || x < 0 || y < 0)
                Process.GetCurrentProcess().Kill();
            Bitmap bitmap = (Bitmap)_pictureBoxes[x, y].Image;
            Color color = Color.LightGreen;
            if (state == true)
                color = Color.DarkGreen;
            for (int i = 1; i < 24; i++)
                for (int o = 1; o < 24; o++)
                    bitmap.SetPixel(i, o, color);
            _pictureBoxes[x, y].Image = bitmap;
        }
        internal PictureBox[,] _pictureBoxes = new PictureBox[20, 20];
        internal void CreatePictureBox()
        {
            for (int i = 0; i < 20; i++)
                for (int o = 0; o < 20; o++)
                {
                    _pictureBoxes[i, o] = new PictureBox();
                    _pictureBoxes[i, o].Size = new Size(25, 25);
                    _pictureBoxes[i, o].Location = new Point(i * 25, o * 25);
                    Bitmap tempBitmap = new Bitmap(25, 25);
                    for (int x = 0; x < 25; x++)
                        for (int y = 0; y < 25; y++)
                            tempBitmap.SetPixel(x, y, Color.LightGreen);
                    for (int p = 0; p < 2; p++)
                    {
                        for (int ii = 0; ii < 25; ii++)
                        {
                            tempBitmap.SetPixel(p * 24, ii, Color.Green);
                            tempBitmap.SetPixel(ii, p * 24, Color.Green);
                        }
                    }
                    _pictureBoxes[i, o].Image = tempBitmap;
                    panel1.Controls.Add(_pictureBoxes[i, o]);
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool boolj = false;
            switch (keyData)
            {
                case (Keys.W):
                    for (int i = 0; i < snake.Count; i++)
                        if (snake[i][1] == snake[0][1] - 1 && snake[i][0] == snake[0][0])
                            boolj = true;                        
                    if (boolj == false)
                        direction = "up";
                    boolj = false;
                    return true;
                case (Keys.A):
                    for (int i = 0; i < snake.Count; i++)
                        if (snake[i][1] == snake[0][1] && snake[i][0] == snake[0][0] - 1)
                            boolj = true;
                    if (boolj == false)
                        direction = "left";
                    boolj = false;
                    return true;
                case (Keys.D):
                    for (int i = 0; i < snake.Count; i++)
                        if (snake[i][1] == snake[0][1] && snake[i][0] == snake[0][0] + 1)
                            boolj = true;
                    if (boolj == false)
                        direction = "right";
                    boolj = false;
                    return true;
                case (Keys.S):
                    for (int i = 0; i < snake.Count; i++)
                        if (snake[i][1] == snake[0][1] + 1 && snake[i][0] == snake[0][0])
                            boolj = true;
                    if (boolj == false)
                        direction = "down";
                    boolj = false;
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            CreatePictureBox();
            Thread.Sleep(3000);
            DrawedPixel(10, 10, true);
            snake.Add(new int[] { 10, 10 });
            Bitmap bitmap = (Bitmap)_pictureBoxes[apple[0], apple[1]].Image;
            for (int i = 0; i < 15; i++)
                for (int o = 0; o < 15; o++)
                    bitmap.SetPixel(i + 5, o + 5, Color.Red);
            _pictureBoxes[apple[0], apple[1]].Image = bitmap;
            timer1.Enabled = true;
        }
        Random rnd = new Random();
        int[] apple = new int[2] { 15, 15};
        internal void CreateApple()
        {
            apple = new int[2] { rnd.Next(0, 19), rnd.Next(0, 19) };
            Bitmap bitmap = (Bitmap)_pictureBoxes[apple[0], apple[1]].Image;
            for (int i = 0; i < 15; i++)
                for (int o = 0; o < 15; o++)
                    bitmap.SetPixel(i + 5, o + 5, Color.Red);
            _pictureBoxes[apple[0], apple[1]].Image = bitmap;
        }
        internal string direction = "up";
        internal List<int[]> snake2 = new List<int[]>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (direction)
            {
                case ("up"):
                    for (int i = 0; i < snake.Count; i++)
                        if (snake[0][0] == snake[i][0] && snake[0][1] - 1 == snake[i][1])
                            Process.GetCurrentProcess().Kill();
                    snake2 = new List<int[]>();
                    DrawedPixel((snake[0][0]), (snake[0][1] - 1), true);
                    snake2.Add(new int[] { (snake[0][0]), (snake[0][1] - 1) });
                    snake2.AddRange(snake);
                    snake = snake2;
                    snake2 = null;
                    if (apple[0] == snake[0][0] && apple[1] == snake[0][1])
                        CreateApple();
                    else
                    {
                        DrawedPixel((snake[snake.Count - 1][0]), (snake[snake.Count - 1][1]), false);
                        snake.RemoveAt(snake.Count - 1);
                    }
                    break;
                case ("left"):
                    for (int i = 0; i < snake.Count; i++)
                        if (snake[0][0] - 1 == snake[i][0] && snake[0][1] == snake[i][1])
                            Process.GetCurrentProcess().Kill();
                    snake2 = new List<int[]>();
                    DrawedPixel((snake[0][0] - 1), (snake[0][1]), true);
                    snake2.Add(new int[] { (snake[0][0] - 1), (snake[0][1]) });
                    snake2.AddRange(snake);
                    snake = snake2;
                    snake2 = null;
                    if (apple[0] == snake[0][0] && apple[1] == snake[0][1])
                        CreateApple();
                    else
                    {
                        DrawedPixel((snake[snake.Count - 1][0]), (snake[snake.Count - 1][1]), false);
                        snake.RemoveAt(snake.Count - 1);
                    }
                    break;
                case ("right"):
                    for (int i = 0; i < snake.Count; i++)
                        if (snake[0][0] + 1 == snake[i][0] && snake[0][1] == snake[i][1])
                            Process.GetCurrentProcess().Kill();
                    snake2 = new List<int[]>();
                    DrawedPixel((snake[0][0] + 1), (snake[0][1]), true);
                    snake2.Add(new int[] { (snake[0][0] + 1), (snake[0][1]) });
                    snake2.AddRange(snake);
                    snake = snake2;
                    snake2 = null;
                    if (apple[0] == snake[0][0] && apple[1] == snake[0][1])
                        CreateApple();
                    else
                    {
                        DrawedPixel((snake[snake.Count - 1][0]), (snake[snake.Count - 1][1]), false);
                        snake.RemoveAt(snake.Count - 1);
                    }
                    break;
                case ("down"):
                    for (int i = 0; i < snake.Count; i++)
                        if (snake[0][0]  == snake[i][0] && snake[0][1] + 1 == snake[i][1])
                            Process.GetCurrentProcess().Kill();
                    snake2 = new List<int[]>();
                    DrawedPixel((snake[0][0]), (snake[0][1] + 1), true);
                    snake2.Add(new int[] { (snake[0][0]), (snake[0][1] + 1) });
                    snake2.AddRange(snake);
                    snake = snake2;
                    snake2 = null;
                    if (apple[0] == snake[0][0] && apple[1] == snake[0][1])
                        CreateApple();
                    else
                    {
                        DrawedPixel((snake[snake.Count - 1][0]), (snake[snake.Count - 1][1]), false);
                        snake.RemoveAt(snake.Count - 1);
                    }
                    break;
            }
        }
    }
}