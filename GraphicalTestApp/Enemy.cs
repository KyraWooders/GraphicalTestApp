using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Enemy : Entity
    {
        private Direction _facing;
        public float Speed { get; set; } = 175f;
        private Sprite sprite;
        private AABB _hitBox;
        private static Enemy _instance;

        //creates a new enemy
        public Enemy(float x, float y) : base(x, y)
        {
            _facing = Direction.North;
            OnUpdate += Move;

            _instance = this;

            sprite = new Sprite("gameAssets/000.png");
            AddChild(sprite);

            _hitBox = new AABB(sprite.Width, sprite.Height);
            AddChild(_hitBox);

            OnUpdate += TouchSword;
            OnUpdate += TouchPlayer;
            //OnUpdate += TouchBullet;
        }
        
        public static Enemy Instance
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

        //if the Enemy has touched the sword, remove itself
        private void TouchSword(float deltaTime)
        {
            if (Player.Instance.Parent != null)
            {
                if (Sword.Instance.HitBox.DetectCollision(HitBox))
                {
                    Parent.RemoveChild(this);
                }
            }
        }

        //if the Enemy has touched the player, remove the player
        private void TouchPlayer(float deltaTime)
        {
            if (Player.Instance.HitBox.DetectCollision(HitBox))
            {
                if (Player.Instance.Parent != null)
                {
                    Player.Instance.Parent.RemoveChild(Player.Instance);
                }
            }
        }

        //if the Enemy has touched bullets, remove itself
        private void TouchBullet(float deltaTime)
        {
            if (Bullet.Instance.HitBox.DetectCollision(HitBox))
            {
                    Parent.RemoveChild(this);
            }
        }

        //Move in the direction the Enemy is facing
        private void Move(float deltaTime)
        {
            //Rotate(0.09f);
            switch (_facing)
            {
                case Direction.North:
                    MoveUp(deltaTime);
                    break;
                case Direction.South:
                    MoveDown(deltaTime);
                    break;
                case Direction.East:
                    MoveRight(deltaTime);
                    break;
                case Direction.West:
                    MoveLeft(deltaTime);
                    break;
            }
        }

        //Move one space down
        private void MoveDown(float deltaTime)
        {
            YVelocity = Speed * deltaTime;
            if (Y >= 727)
            {
                _facing++;
            }
        }

        //Move one space right
        private void MoveRight(float deltaTime)
        {
            XVelocity = Speed * deltaTime;
            if (X >= 1247)
            {
                _facing++;
            }
            
        }

        //Move one space left
        private void MoveLeft(float deltaTime)
        {
            XVelocity = -(Speed * deltaTime);
            if (X <= 33)
            {
                _facing = Direction.North;
            }
        }

        //move one space up
        private void MoveUp(float deltaTime)
        {
            YVelocity = -(Speed * deltaTime);
            if (Y <= 33)
            {
                _facing++;
            }
            
        }
    }
}
