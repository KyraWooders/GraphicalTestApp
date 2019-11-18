using System;

namespace GraphicalTestApp
{
    class AABB : Actor
    {
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;
        private bool[,] _collision;
        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute; }
        }

        //Returns the Y coordinate at the top of the box
        public float Bottom
        {
            get { return YAbsolute + Height; }
        }

        //Returns the X coordinate at the top of the box
        public float Left
        {
            get { return XAbsolute; }
        }

        //Returns the X coordinate at the top of the box
        public float Right
        {
            get { return XAbsolute + Width; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public bool DetectCollision(AABB other)
        {
            //## Implement DetectCollision(AABB) ##//
            return false;
        }

        public bool DetectCollision(Vector3 point)
        {
            //## Implement DetectCollision(Vector3) ##//
            return false;
        }

        //Draw the bounding box to the screen
        public override void Draw()
        {
            Raylib.Rectangle rec = new Raylib.Rectangle(XAbsolute, YAbsolute, Width, Height);
            Raylib.Raylib.DrawRectangleLinesEx(rec, 1, Raylib.Color.RED);
        }
    }
}
