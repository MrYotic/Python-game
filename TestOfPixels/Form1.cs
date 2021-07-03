using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
namespace TestOfPixels{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
            DrawedPixel(10, 10, true);
            CreateApple(new Random(), new Random());}
        internal List<int[]> snake = new List<int[]>() { new int[] { 10, 10 } };
        internal void DrawedPixel(int x, int y, bool state){ 
            if (x > 19 || y > 19 || x < 0 || y < 0) Process.GetCurrentProcess().Kill();
            Bitmap bitmap = (Bitmap)_pictureBoxes[x, y].Image;
            Color color = Color.LightGreen;
            if (state == true)
                color = Color.DarkGreen;
            for (int i = 1; i < 24 * 24; i++)
                  bitmap.SetPixel(i / 24, i % 24, color);
            _pictureBoxes[x, y].Image = bitmap;}
        int[] apple = new int[2] { 15, 15};
        internal void CreateApple(Random r1, Random r2){
            apple = new int[2] { new Random(r1.Next(1, 999)).Next(0, 19), new Random(r2.Next(1, 999)).Next(0, 19) };
            for (int i = 0; i < snake.Count; i++)
                if (snake[i][0] == apple[0] && snake[i][1] == apple[1]){
                    CreateApple(new Random(), new Random());
                    return;}
            Bitmap bitmap = (Bitmap)_pictureBoxes[apple[0], apple[1]].Image;
            for (int i = 0; i < 15 * 15; i++) bitmap.SetPixel(i / 15 + 5, i % 15 + 5, Color.Red);
            _pictureBoxes[apple[0], apple[1]].Image = bitmap;
        }
        internal Keys direction = Keys.W;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData){
            for (int o = 0; o < snake.Count; o++)
                if (((keyData == Keys.W ? 0 : (keyData == Keys.A ? 1 : (keyData == Keys.D ? 2 : (keyData == Keys.S ? 3 : 100)))) == 0 ? (snake[o][1] == snake[0][1] - 1 && snake[o][0] == snake[0][0]) : ((keyData == Keys.W ? 0 : (keyData == Keys.A ? 1 : (keyData == Keys.D ? 2 : (keyData == Keys.S ? 3 : 100)))) == 1 ? (snake[o][1] == snake[0][1] && snake[o][0] == snake[0][0] - 1) : ((keyData == Keys.W ? 0 : (keyData == Keys.A ? 1 : (keyData == Keys.D ? 2 : (keyData == Keys.S ? 3 : 100)))) == 2 ? (snake[o][1] == snake[0][1] && snake[o][0] == snake[0][0] + 1) : ((snake[o][1] == snake[0][1] + 1 && snake[o][0] == snake[0][0]))))) && (keyData == Keys.W ? 0 : (keyData == Keys.A ? 1 : (keyData == Keys.D ? 2 : (keyData == Keys.S ? 3 : 100)))) < 5) return true;
            direction = keyData;
            return base.ProcessCmdKey(ref msg, keyData);}
        private void timer1_Tick(object sender, EventArgs e){
            for (int i = 0; i < snake.Count; i++)
                if ((direction == Keys.W ? (snake[0][0] == snake[i][0] && snake[0][1] - 1 == snake[i][1]) : (direction == Keys.A ? (snake[0][0] - 1 == snake[i][0] && snake[0][1] == snake[i][1]) : (direction == Keys.D ? (snake[0][0] + 1 == snake[i][0] && snake[0][1] == snake[i][1]) : (direction == Keys.S ? (snake[0][0] == snake[i][0] && snake[0][1] + 1 == snake[i][1]) : false))))) Process.GetCurrentProcess().Kill();
            DrawedPixel(snake[0][0] + (direction == Keys.A ? - 1 : (direction == Keys.D ? + 1 : + 0)), snake[0][1] + (direction == Keys.W ? - 1 : (direction == Keys.S ? 1 : 0)), true);
            snake.Insert(0, new int[] { snake[0][0] + (direction == Keys.A ? -1 : (direction == Keys.D ? +1 : +0)), snake[0][1] + (direction == Keys.W ? -1 : (direction == Keys.S ? 1 : 0)) });
            if (apple[0] == snake[0][0] && apple[1] == snake[0][1]) CreateApple(new Random(), new Random());
            else{
                DrawedPixel((snake[snake.Count - 1][0]), (snake[snake.Count - 1][1]), false);
                snake.RemoveAt(snake.Count - 1);}}}}