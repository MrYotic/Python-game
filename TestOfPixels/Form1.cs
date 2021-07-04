namespace TestOfPixels{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1(){
            InitializeComponent();
            DrawedPixel(10, 10, true);
            CreateApple(new System.Random(), new System.Random());}
        internal System.Collections.Generic.List<int[]> snake = new System.Collections.Generic.List<int[]>() { new int[] { 10, 10 } };
        internal void DrawedPixel(int x, int y, bool state){ 
            if (x > 19 || y > 19 || x < 0 || y < 0) System.Diagnostics.Process.GetCurrentProcess().Kill();
            System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)_pictureBoxes[x, y].Image;
            System.Drawing.Color color = System.Drawing.Color.LightGreen;
            if (state == true)
                color = System.Drawing.Color.DarkGreen;
            for (int i = 1; i < 24 * 24; i++)
                  bitmap.SetPixel(i / 24, i % 24, color);
            _pictureBoxes[x, y].Image = bitmap;}
        int[] apple = new int[2] { 15, 15};
        internal void CreateApple(System.Random r1, System.Random r2){
            apple = new int[2] { new System.Random(r1.Next(1, 999)).Next(0, 19), new System.Random(r2.Next(1, 999)).Next(0, 19) };
            for (int i = 0; i < snake.Count; i++)
                if (snake[i][0] == apple[0] && snake[i][1] == apple[1]){
                    CreateApple(new System.Random(), new System.Random());
                    return;}
            System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)_pictureBoxes[apple[0], apple[1]].Image;
            for (int i = 0; i < 15 * 15; i++) bitmap.SetPixel(i / 15 + 5, i % 15 + 5, System.Drawing.Color.Red);
            _pictureBoxes[apple[0], apple[1]].Image = bitmap;
        }
        internal System.Windows.Forms.Keys direction = System.Windows.Forms.Keys.W;
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData){
            for (int o = 0; o < snake.Count; o++)
                if (((keyData == System.Windows.Forms.Keys.W ? 0 : (keyData == System.Windows.Forms.Keys.A ? 1 : (keyData == System.Windows.Forms.Keys.D ? 2 : (keyData == System.Windows.Forms.Keys.S ? 3 : 100)))) == 0 ? (snake[o][1] == snake[0][1] - 1 && snake[o][0] == snake[0][0]) : ((keyData == System.Windows.Forms.Keys.W ? 0 : (keyData == System.Windows.Forms.Keys.A ? 1 : (keyData == System.Windows.Forms.Keys.D ? 2 : (keyData == System.Windows.Forms.Keys.S ? 3 : 100)))) == 1 ? (snake[o][1] == snake[0][1] && snake[o][0] == snake[0][0] - 1) : ((keyData == System.Windows.Forms.Keys.W ? 0 : (keyData == System.Windows.Forms.Keys.A ? 1 : (keyData == System.Windows.Forms.Keys.D ? 2 : (keyData == System.Windows.Forms.Keys.S ? 3 : 100)))) == 2 ? (snake[o][1] == snake[0][1] && snake[o][0] == snake[0][0] + 1) : ((snake[o][1] == snake[0][1] + 1 && snake[o][0] == snake[0][0]))))) && (keyData == System.Windows.Forms.Keys.W ? 0 : (keyData == System.Windows.Forms.Keys.A ? 1 : (keyData == System.Windows.Forms.Keys.D ? 2 : (keyData == System.Windows.Forms.Keys.S ? 3 : 100)))) < 5) return true;
            direction = keyData;
            return base.ProcessCmdKey(ref msg, keyData);}
        private void timer1_Tick(object sender, System.EventArgs e){
            for (int i = 0; i < snake.Count; i++)
                if ((direction == System.Windows.Forms.Keys.W ? (snake[0][0] == snake[i][0] && snake[0][1] - 1 == snake[i][1]) : (direction == System.Windows.Forms.Keys.A ? (snake[0][0] - 1 == snake[i][0] && snake[0][1] == snake[i][1]) : (direction == System.Windows.Forms.Keys.D ? (snake[0][0] + 1 == snake[i][0] && snake[0][1] == snake[i][1]) : (direction == System.Windows.Forms.Keys.S ? (snake[0][0] == snake[i][0] && snake[0][1] + 1 == snake[i][1]) : false))))) System.Diagnostics.Process.GetCurrentProcess().Kill();
            DrawedPixel(snake[0][0] + (direction == System.Windows.Forms.Keys.A ? - 1 : (direction == System.Windows.Forms.Keys.D ? + 1 : + 0)), snake[0][1] + (direction == System.Windows.Forms.Keys.W ? - 1 : (direction == System.Windows.Forms.Keys.S ? 1 : 0)), true);
            snake.Insert(0, new int[] { snake[0][0] + (direction == System.Windows.Forms.Keys.A ? -1 : (direction == System.Windows.Forms.Keys.D ? +1 : +0)), snake[0][1] + (direction == System.Windows.Forms.Keys.W ? -1 : (direction == System.Windows.Forms.Keys.S ? 1 : 0)) });
            if (apple[0] == snake[0][0] && apple[1] == snake[0][1]) CreateApple(new System.Random(), new System.Random());
            else{
                DrawedPixel((snake[snake.Count - 1][0]), (snake[snake.Count - 1][1]), false);
                snake.RemoveAt(snake.Count - 1);}}}}