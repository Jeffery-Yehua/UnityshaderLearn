using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Dtrans
{
    class Triangle3D
    {
        private Vector4 a, b, c;
        public Vector4 A, B, C;

        public Triangle3D()
        {
        }
        public Triangle3D(Vector4 a,Vector4 b , Vector4 c)
        {
            this.A = this.a=new Vector4(a);
            this.B = this.b=new Vector4(b);
            this.C = this.c=new Vector4(c);
        }

        //利用矩阵乘法进行顶点变换
        public void Transform(Matrix4x4 m)
        {
            this.a = m.Mul(A);
            this.b = m.Mul(B);
            this.c = m.Mul(C);
        }
        //绘制三角形
        public void Draw(Graphics g)
        {
            g.TranslateTransform(300, 300);
            g.DrawLines(new Pen(Color.Red, 2), this.GetPointFArr());
        }
        private PointF[] GetPointFArr()
        {
            PointF[] arr = new PointF[4];
            arr[0] = GetPointF(this.a);
            arr[1] = GetPointF(this.b);
            arr[2] = GetPointF(this.c);
            arr[3] = arr[0];
            return arr;
        }
        private PointF GetPointF (Vector4 v)
        {
            PointF p = new PointF();
            p.X = (float)(v.x / v.w);
            p.Y = (float)(v.y / v.w);
            return p;
        }
    }
}

