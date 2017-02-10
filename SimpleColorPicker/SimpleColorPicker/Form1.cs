using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleColorPicker
{
    public partial class frmMain : Form
    {
        Bitmap img;
        public frmMain()
        {
            InitializeComponent();
            tmrRefresh.Interval = 1000 / 30;
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            img = new Bitmap(200, 200);
            using (Graphics g = Graphics.FromImage(img))
            using (Graphics pnl = pnlMain.CreateGraphics())
            {
                g.CopyFromScreen(Cursor.Position.X - 100, Cursor.Position.Y - 100, 0, 0, new Size(200, 200), CopyPixelOperation.SourceCopy);
                pnl.DrawImage(img, new Point(0, 0));
                pnl.DrawLine(new Pen(Color.Red, 1), new Point(pnlMain.Width / 2, 0), new Point(pnlMain.Width / 2, pnlMain.Height));
                pnl.DrawLine(new Pen(Color.Red, 1), new Point(0, pnlMain.Height / 2), new Point(pnlMain.Width, pnlMain.Height / 2));
                Color c = img.GetPixel(img.Width / 2, img.Height / 2);

                lblRGB.Text = string.Format("RVB : {0}, {1}, {2}", c.R, c.G, c.B);
                lblName.Text = string.Format("Mouse position : {0} x, {1} y", Cursor.Position.X, Cursor.Position.Y);
                pnlColor.BackColor = c;
            }
            img.Dispose();
        }
    }
}
