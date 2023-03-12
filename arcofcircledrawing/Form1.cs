using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arcofcircledrawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private PointF point1;
        private PointF point2;
        private float radius;

        public Form1(PointF point1, PointF point2, float radius)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.radius = radius;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            // Calculate the rectangle that bounds the circle
            float x = Math.Min(point1.X, point2.X) - radius;
            float y = Math.Min(point1.Y, point2.Y) - radius;
            float width = Math.Abs(point1.X - point2.X) + 2 * radius;
            float height = Math.Abs(point1.Y - point2.Y) + 2 * radius;
            RectangleF rect = new RectangleF(x, y, width, height);

            // Calculate the start and sweep angles
            double startAngle = Math.Atan2(point1.Y - rect.Y - height / 2, point1.X - rect.X - width / 2) * 180 / Math.PI;
            double endAngle = Math.Atan2(point2.Y - rect.Y - height / 2, point2.X - rect.X - width / 2) * 180 / Math.PI;
            float sweepAngle = (float)(endAngle - startAngle);

            // Draw the arc
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawArc(pen, rect, (float)startAngle, sweepAngle);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
