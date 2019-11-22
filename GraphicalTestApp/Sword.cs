using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Sword : Entity
    {
        public Sword(float x, float y) : base(x, y)
        {
            Sprite sprite = new Sprite("gameAssets/crying.jpg");
            AddChild(sprite);
            OnUpdate += RotateSword;
        }

        private void RotateSword(float deltaTime)
        {
            if (Input.IsKeyDown(262))
            {
                Rotate(5f * deltaTime);
            }
            if (Input.IsKeyDown(263))
            {
                Rotate(-5f * deltaTime);
            }
        }
    }
}
