using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3Dtrans
{
  
    public partial class Form1 : Form
    {
        int a;
        Triangle3D t;
        Matrix4x4 m_scale;
        Matrix4x4 m_rotate;
        Matrix4x4 m_view;
        Matrix4x4 m_projection;

        public Form1()
        {
            InitializeComponent();
            m_scale = new Matrix4x4();
            m_scale[1, 1] = 250;
            m_scale[2, 2] = 250;
            m_scale[3, 3] = 250;
            m_scale[4, 4] = 1;

            m_view = new Matrix4x4();
            m_view[1, 1] = 1;
            m_view[2, 2] = 1;
            m_view[3, 3] = 1;
            m_view[4, 3] = 250;
            m_view[4, 4] = 1;
            

            m_projection = new Matrix4x4();
            m_projection[1, 1] = 1;
            m_projection[2, 2] = 1;
            m_projection[3, 3] = 1;
            m_projection[3, 4] = 1.0 / 250;
            m_projection[4, 4] = 1;


            m_rotate = new Matrix4x4();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Vector4 a = new Vector4(0, -0.5, 0, 1);
            Vector4 b = new Vector4(0.5, 0.5, 0, 1);
            Vector4 c = new Vector4(-0.5, 0.5, 0, 1);
            t = new Triangle3D(a, b, c);
           
        }
        

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            t.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            a += 2;
            double angle = a / 360.0 * Math.PI;

           

            m_rotate[1,1] = Math.Cos(angle);
            m_rotate[1,3] = Math.Sin(angle);
            m_rotate[2, 2] = 1;
            m_rotate[3, 1] = -Math.Sin(angle);
            m_rotate[3, 3] = Math.Cos(angle);
            m_rotate[4, 4] = 1;

            Matrix4x4 m = m_scale.Mul(m_rotate);
            m = m.Mul(m_view);
            m = m.Mul(m_projection);
            t.Transform(m);
            this.Invalidate();
        }
    }
}
