using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Vector3
    {
        public float x;
        public float y;
        public float z;

        //Creates a Vector3 with x, y, and z at 0
        public Vector3() : this(0f, 0f, 0f)
        {

        }

        //Creates a Vector3 with x, y, and z at the specified values
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //Vector3 + Vector3
        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }

        //Vector3 - Vector3
        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x - rhs.x, lhs.y - rhs.y, lhs.z - rhs.z);
        }

        //Vector3 * float
        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x * rhs, lhs.y * rhs, lhs.z * rhs);
        }

        //float * Vector3
        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs * rhs.x, lhs * rhs.y, lhs * rhs.z);
        }

        //Vector3 / float
        public static Vector3 operator /(Vector3 lhs, float rhs)
        {
            return new Vector3(lhs.x / rhs, lhs.y / rhs, lhs.z / rhs);
        }

        //float / Vector3
        public static Vector3 operator /(float lhs, Vector3 rhs)
        {
            return new Vector3(lhs / rhs.x, lhs / rhs.y, lhs / rhs.z);
        }

        //Returns the magnitude of the Vector3
        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        //Returns the square of the magnitude of the Vector3
        public float MagitudeSqr()
        {
            return (x * x + y * y + z * z);
        }

        //Returns the distance between this Vector3 and another
        public float Distance(Vector3 other)
        {
            float diffx = x - other.x;
            float diffy = y - other.y;
            float diffz = z - other.z;
            return (float)Math.Sqrt(diffx * diffx + diffy * diffy + diffz * diffz);
        }

        //Returns the dot product of this Vector3 and another
        public float Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }

        //Returns the cross product of this Vector3 and another
        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(
                y * rhs.z - z * rhs.y,
                z * rhs.x - x * rhs.z,
                x * rhs.y - y * rhs.x);
        }
        
        public override string ToString()
        {
            return "{" + x + "," + y + "," + z + "}";
        }

        //Normalizes this Vector3
        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
        }

        //Returns a normalized Vector3 without modifying this one
        public Vector3 GetNormalize()
        {
            return (this / Magnitude());
        }

        public float GetAngle(Vector3 other)
        {
            Vector3 a = GetNormalize();
            Vector3 b = other.GetNormalize();
            return (float)Math.Acos(a.Dot(b));
        }

        public static Vector3 Min(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Min(a.x, b.x), Math.Min(a.y, b.y), Math.Min(a.z, b.z));
        }

        public static Vector3 Max(Vector3 a, Vector3 b)
        {
            return new Vector3(Math.Max(a.x, b.x), Math.Max(a.y, b.y), Math.Max(a.z, b.z));
        }

        public static Vector3 Clamp(Vector3 t, Vector3 a, Vector3 b)
        {
            return Max(a, Min(b, t));
        }
    }
}
