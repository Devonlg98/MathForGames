using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public struct Matrix4
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;
        public static Matrix4 identity = new Matrix4(1, 0, 0, 0,
                                                     0, 1, 0, 0,
                                                     0, 0, 1, 0,
                                                     0, 0, 0, 1);

        Matrix4 GetTransposed()
        {
            return new Matrix4(m1, m5, m9, m13, m2, m6, m10, m14, m3, m7, m11, m15, m4, m8, m12, m16);
        }
        public Matrix4(float val_1, float val_2, float val_3, float val_4, float val_5, float val_6, float val_7, float val_8, float val_9,
            float val_10, float val_11, float val_12, float val_13, float val_14, float val_15, float val_16)
        {
            m1 = val_1; m2 = val_2; m3 = val_3; m4 = val_4;
            m5 = val_5; m6 = val_6; m7 = val_7; m8 = val_8;
            m9 = val_9; m10 = val_10; m11 = val_11; m12 = val_12;
            m13 = val_13; m14 = val_14; m15 = val_15; m16 = val_16;
        }
        public static Matrix4 operator *(Matrix4 rhs, Matrix4 lhs)
        {
            return new Matrix4
           (lhs.m1 * rhs.m1 + lhs.m2 * rhs.m5 + lhs.m3 * rhs.m9 + lhs.m4 * rhs.m13,
            lhs.m1 * rhs.m2 + lhs.m2 * rhs.m6 + lhs.m3 * rhs.m10 + lhs.m4 * rhs.m14,
            lhs.m1 * rhs.m3 + lhs.m2 * rhs.m7 + lhs.m3 * rhs.m11 + lhs.m4 * rhs.m15,
            lhs.m1 * rhs.m4 + lhs.m2 * rhs.m8 + lhs.m3 * rhs.m12 + lhs.m4 * rhs.m16,

            lhs.m5 * rhs.m1 + lhs.m6 * rhs.m5 + lhs.m7 * rhs.m9 + lhs.m8 * rhs.m13,
            lhs.m5 * rhs.m2 + lhs.m6 * rhs.m6 + lhs.m7 * rhs.m10 + lhs.m8 * rhs.m14,
            lhs.m5 * rhs.m3 + lhs.m6 * rhs.m7 + lhs.m7 * rhs.m11 + lhs.m8 * rhs.m15,
            lhs.m5 * rhs.m4 + lhs.m6 * rhs.m8 + lhs.m7 * rhs.m12 + lhs.m8 * rhs.m16,

            lhs.m9 * rhs.m1 + lhs.m10 * rhs.m5 + lhs.m11 * rhs.m9 + lhs.m12 * rhs.m13,
            lhs.m9 * rhs.m2 + lhs.m10 * rhs.m6 + lhs.m11 * rhs.m10 + lhs.m12 * rhs.m14,
            lhs.m9 * rhs.m3 + lhs.m10 * rhs.m7 + lhs.m11 * rhs.m11 + lhs.m12 * rhs.m15,
            lhs.m9 * rhs.m4 + lhs.m10 * rhs.m8 + lhs.m11 * rhs.m12 + lhs.m12 * rhs.m16,

            lhs.m13 * rhs.m1 + lhs.m14 * rhs.m5 + lhs.m15 * rhs.m9 + lhs.m16 * rhs.m13,
            lhs.m13 * rhs.m2 + lhs.m14 * rhs.m6 + lhs.m15 * rhs.m10 + lhs.m16 * rhs.m14,
            lhs.m13 * rhs.m3 + lhs.m14 * rhs.m7 + lhs.m15 * rhs.m11 + lhs.m16 * rhs.m15,
            lhs.m13 * rhs.m4 + lhs.m14 * rhs.m8 + lhs.m15 * rhs.m12 + lhs.m16 * rhs.m16);
        }
        //public static Vector4 operator *(Matrix4 lhs, Vector4 rhs)
        //{
        //    return new Vector4
        //       ((lhs.m1 * rhs.x) + (lhs.m2 * rhs.y) + (lhs.m3 * rhs.z) + (lhs.m4 * rhs.w),
        //        (lhs.m5 * rhs.x) + (lhs.m6 * rhs.y) + (lhs.m7 * rhs.z) + (lhs.m8 * rhs.w),
        //        (lhs.m9 * rhs.x) + (lhs.m10 * rhs.y) + (lhs.m11 * rhs.z) + (lhs.m12 * rhs.w),
        //        (lhs.m13 * rhs.x) + (lhs.m14 * rhs.y) + (lhs.m15 * rhs.z) + (lhs.m16 * rhs.w));
        //}
        Matrix4 GetTansposed()
        {
            // flip row and column
            return new Matrix4
          (m1, m5, m9, m13,
           m2, m6, m10, m14,
           m3, m7, m11, m15,
           m4, m8, m12, m16);
        }
        public void Set(float val_1, float val_2, float val_3, float val_4, float val_5, float val_6, float val_7, float val_8, float val_9,
            float val_10, float val_11, float val_12, float val_13, float val_14, float val_15, float val_16)
        {
            m1 = val_1; m2 = val_2; m3 = val_3; m4 = val_4;
            m5 = val_5; m6 = val_6; m7 = val_7; m8 = val_8;
            m9 = val_9; m10 = val_10; m11 = val_11; m12 = val_12;
            m13 = val_13; m14 = val_14; m15 = val_15; m16 = val_16;
        }
        public void Set(Matrix4 m)
        {
            m1 = m.m1; m2 = m.m2; m3 = m.m3; m4 = m.m4;
            m5 = m.m5; m6 = m.m6; m7 = m.m7; m8 = m.m8;
            m9 = m.m9; m10 = m.m10; m11 = m.m11; m12 = m.m12;
            m13 = m.m13; m14 = m.m14; m15 = m.m15; m16 = m.m16;
        }

        public void SetRotateX(double radians)
        {
            Set(1, 0, 0, 0,
            0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
            0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
            0, 0, 0, 1);
        }
        public void SetRotateY(double radians)
        {
            Set((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
            0, 1, 0, 0,
            (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
            0, 0, 0, 1);
        }
        public void SetRotateZ(double radians)
        {
            Set((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
            (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1);
        }
        public void RotateX(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateX(radians);
            Set(this * m);
        }
        public void RotateY(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateY(radians);
            Set(this * m);
        }
        public void RotateZ(double radians)
        {
            Matrix4 m = new Matrix4();
            m.SetRotateZ(radians);
            Set(this * m);
        }
        void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix4 x = new Matrix4();
            Matrix4 y = new Matrix4();
            Matrix4 z = new Matrix4();
            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);
            // combine rotations in a specific order
            Set(z * y * x);
        }
        public void SetTranslation(float x, float y, float z)
        {
            m13 = z; m14 = y; m15 = z; m16 = 1;
        }        void Translate(float x, float y, float z)
        {
            // apply vector offset
            m13 += z; m14 += y; m15 += z;
        }
    }
}
