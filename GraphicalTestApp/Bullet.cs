using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        private Direction _facing;
        public float Speed { get; set; } = 175f;
        Sprite _sprite;
        AABB _hitBox;
        private static Bullet _instance;

        public Bullet(float x, float y) : base(x, y)
        {
            _instance = this;

            _sprite = new Sprite("gameAssets/bullet.png");
            AddChild(_sprite);

            _hitBox = new AABB(_sprite.Width, _sprite.Height);
            AddChild(_hitBox);

            //OnUpdate += Move;
        }

        public static Bullet Instance
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

        //Move one space down
        public void MoveDown(float deltaTime)
        {
            YVelocity = Speed * deltaTime;
            //_facing = Direction.South;
        }

        //move one space up
        public void MoveUp(float deltaTime)
        {
            YVelocity = -(Speed * deltaTime);
            //_facing = Direction.North;
        }

        //Move in the direction the Enemy is facing
        private void Move(float deltaTime)
        {
            switch (_facing)
            {
                case Direction.North:
                    MoveUp(deltaTime);
                    break;
                case Direction.South:
                    MoveDown(deltaTime);
                    break;
            }
        }
    }
}
