namespace a{
    public partial class aa : System.Windows.Forms.Form{
        public aa(){
            a111();
            a1(10, 10, true);
            aaa(new System.Random(), new System.Random());}
        internal System.Collections.Generic.List<int[]> aa1 = new System.Collections.Generic.List<int[]>() { new int[] { 10, 10 } };
        internal void a1(int x, int y, bool aaaa){ 
            if (x > 19 || y > 19 || x < 0 || y < 0) System.Diagnostics.Process.GetCurrentProcess().Kill();
            System.Drawing.Bitmap a1a = (System.Drawing.Bitmap)a11[x, y].Image;
            System.Drawing.Color aa1 = System.Drawing.Color.LightGreen;
            if (aaaa == true)
                aa1 = System.Drawing.Color.DarkGreen;
            for (int i = 1; i < 24 * 24; i++)
                  a1a.SetPixel(i / 24, i % 24, aa1);
            a11[x, y].Image = a1a;}
        int[] aaa1 = new int[2] { 15, 15};
        internal void aaa(System.Random r1, System.Random r2){
            aaa1 = new int[2] { new System.Random(r1.Next(1, 999)).Next(0, 19), new System.Random(r2.Next(1, 999)).Next(0, 19) };
            for (int i = 0; i < aa1.Count; i++)
                if (aa1[i][0] == aaa1[0] && aa1[i][1] == aaa1[1]){
                    aaa(new System.Random(), new System.Random());
                    return;}
            System.Drawing.Bitmap aa1a = (System.Drawing.Bitmap)a11[aaa1[0], aaa1[1]].Image;
            for (int i = 0; i < 15 * 15; i++) aa1a.SetPixel(i / 15 + 5, i % 15 + 5, System.Drawing.Color.Red);
            a11[aaa1[0], aaa1[1]].Image = aa1a;}
        internal System.Windows.Forms.Keys aa11 = System.Windows.Forms.Keys.W;
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message a1a1, System.Windows.Forms.Keys a1aa){
            for (int o = 0; o < aa1.Count; o++)
                if (((a1aa == System.Windows.Forms.Keys.W ? 0 : (a1aa == System.Windows.Forms.Keys.A ? 1 : (a1aa == System.Windows.Forms.Keys.D ? 2 : (a1aa == System.Windows.Forms.Keys.S ? 3 : 100)))) == 0 ? (aa1[o][1] == aa1[0][1] - 1 && aa1[o][0] == aa1[0][0]) : ((a1aa == System.Windows.Forms.Keys.W ? 0 : (a1aa == System.Windows.Forms.Keys.A ? 1 : (a1aa == System.Windows.Forms.Keys.D ? 2 : (a1aa == System.Windows.Forms.Keys.S ? 3 : 100)))) == 1 ? (aa1[o][1] == aa1[0][1] && aa1[o][0] == aa1[0][0] - 1) : ((a1aa == System.Windows.Forms.Keys.W ? 0 : (a1aa == System.Windows.Forms.Keys.A ? 1 : (a1aa == System.Windows.Forms.Keys.D ? 2 : (a1aa == System.Windows.Forms.Keys.S ? 3 : 100)))) == 2 ? (aa1[o][1] == aa1[0][1] && aa1[o][0] == aa1[0][0] + 1) : ((aa1[o][1] == aa1[0][1] + 1 && aa1[o][0] == aa1[0][0]))))) && (a1aa == System.Windows.Forms.Keys.W ? 0 : (a1aa == System.Windows.Forms.Keys.A ? 1 : (a1aa == System.Windows.Forms.Keys.D ? 2 : (a1aa == System.Windows.Forms.Keys.S ? 3 : 100)))) < 5) return true;
            aa11 = a1aa;
            return base.ProcessCmdKey(ref a1a1, a1aa);}
        private void a11a(object aaaaa, System.EventArgs e){
            for (int i = 0; i < aa1.Count; i++)
                if ((aa11 == System.Windows.Forms.Keys.W ? (aa1[0][0] == aa1[i][0] && aa1[0][1] - 1 == aa1[i][1]) : (aa11 == System.Windows.Forms.Keys.A ? (aa1[0][0] - 1 == aa1[i][0] && aa1[0][1] == aa1[i][1]) : (aa11 == System.Windows.Forms.Keys.D ? (aa1[0][0] + 1 == aa1[i][0] && aa1[0][1] == aa1[i][1]) : (aa11 == System.Windows.Forms.Keys.S ? (aa1[0][0] == aa1[i][0] && aa1[0][1] + 1 == aa1[i][1]) : false))))) System.Diagnostics.Process.GetCurrentProcess().Kill();
            a1(aa1[0][0] + (aa11 == System.Windows.Forms.Keys.A ? - 1 : (aa11 == System.Windows.Forms.Keys.D ? + 1 : + 0)), aa1[0][1] + (aa11 == System.Windows.Forms.Keys.W ? - 1 : (aa11 == System.Windows.Forms.Keys.S ? 1 : 0)), true);
            aa1.Insert(0, new int[] { aa1[0][0] + (aa11 == System.Windows.Forms.Keys.A ? -1 : (aa11 == System.Windows.Forms.Keys.D ? +1 : +0)), aa1[0][1] + (aa11 == System.Windows.Forms.Keys.W ? -1 : (aa11 == System.Windows.Forms.Keys.S ? 1 : 0)) });
            if (aaa1[0] == aa1[0][0] && aaa1[1] == aa1[0][1]) aaa(new System.Random(), new System.Random());
            else{
                a1((aa1[aa1.Count - 1][0]), (aa1[aa1.Count - 1][1]), false);
                aa1.RemoveAt(aa1.Count - 1);}}}}