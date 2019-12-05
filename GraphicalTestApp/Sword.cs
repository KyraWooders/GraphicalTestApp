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
        
        //creates a new sword
        public Sword(float x, float y) : base(x, y)
        {
            _instance = this;

            _sprite = new Sprite("gameAssets/eee.png");
            AddChild(_sprite);

            _hitBox = new AABB(_sprite.Width, _sprite.Height);
            AddChild(_hitBox);

            OnUpdate += RotateSword;
        }

        //getting an instance of the sword
        public static Sword Instance
        {
            get
            {
                return _instance;
            }
        }

        //getting an instance to the sword's hitbox
        public AABB HitBox
        {
            get
            {
                return _hitBox;
            }
        }

        //rotates the sword
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
