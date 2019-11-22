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
        private AABB HitBox;

        ////the scene the entity is currently in
        //public AABB CurrentScene { set; get; }

        //cretes a new enemy represented by the 'e' symdol and rat image
        public Enemy(float x, float y) : base(x, y)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            sprite = new Sprite("gameAssets/5PgNs16.jpg");
            AddChild(sprite);
            HitBox = new AABB(sprite.Width, sprite.Height);
            AddChild(HitBox);
            OnUpdate += TouchPlayer;
        }

        //Check to see if the Enemy has touched a player and remove itself if so
        private void TouchPlayer(float deltaTime)
        {
            //get the list of Entities in our space
            if (Player.Instance.HitBox.DetectCollision(HitBox))
            {
                Parent.RemoveChild(this);
            }

            //check if any of them are players
            //foreach (Entity e in touched)
            //{
            //    if (e is Player)
            //    {
            //        RemoveChild(this);
            //        break;
            //    }
            //}
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
            //YVelocity = -0.5f;
            if (Y <= 33)
            {
                _facing++;
            }
            
        }
    }
}
