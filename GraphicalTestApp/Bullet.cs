using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        public float Speed { get; set; } = 60f;
        Sprite _sprite;
        AABB _hitBox;
        
        public Bullet(float x, float y) : base(x, y)
        {
           
            _sprite = new Sprite("gameAssets/bullet.png");
            AddChild(_sprite);

            _hitBox = new AABB(_sprite.Width, _sprite.Height);
            AddChild(_hitBox);
            
        }
        
        public AABB HitBox
        {
            get
            {
                return _hitBox;
            }
        }

        //Move one space down
        public void MoveDown(float deltaTime)
        {
            YVelocity = Speed;
        }

        //move one space up
        public void MoveUp(float deltaTime)
        {
            YVelocity = -Speed;
        }

        
    }
}
