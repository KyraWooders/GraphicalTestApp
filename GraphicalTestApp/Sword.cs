using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Sword : Entity
    {
        Sprite _sprite;
        AABB _hitBox;
        private static Sword _instance;
        

        public Sword(float x, float y) : base(x, y)
        {
            _instance = this;

            _sprite = new Sprite("gameAssets/crying.jpg");
            AddChild(_sprite);

            _hitBox = new AABB(_sprite.Width, _sprite.Height);
            AddChild(_hitBox);

            OnUpdate += RotateSword;
        }

        public static Sword Instance
        {
            get
            {
                return _instance;
            }
        }

        public AABB HitBox
        {
            get
            {
                return _hitBox;
            }
        }

        private void RotateSword(float deltaTime)
        {
            if (Input.IsKeyDown(262))
            {
                Rotate(10f * deltaTime);
            }
            if (Input.IsKeyDown(263))
            {
                Rotate(-10f * deltaTime);
            }
        }
    }
}
