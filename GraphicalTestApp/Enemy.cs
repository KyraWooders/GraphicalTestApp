using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Enemy : Actor
    {
        private Direction _facing;
        public float Speed { get; set; } = 5f;

        //cretes a new enemy represented by the 'e' symdol and rat image
        public Enemy() : this('*')
        {

        }
        public Enemy(char icon) : base(icon)
        {
            _facing = Direction.North;
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        //Creates a new Enemy with the specified symbol
        public Enemy(string imageName) : base('*', imageName)
        {
            //Start the Enemy facing North
            _facing = Direction.North;

            //Add Move and TouchPlayer to the OnUpdate Event
            OnUpdate += Move;
            OnUpdate += TouchPlayer;
        }

        //Check to see if the Enemy has touched a player and remove itself if so
        private void TouchPlayer(float deltaTime)
        {
            //get the list of Entities in our space
            List<Entity> touched = CurrentScene.GetEntities(X, Y);

            //check if any of them are players
            foreach (Entity e in touched)
            {
                if (e is Player)
                {
                    CurrentScene.RemoveEntity(this);
                    break;
                }
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
            //move down if the space is clear
            if (!CurrentScene.DetectCollision(XAbsolute, Sprite.Bottom + Speed * deltaTime))
            {
                YVelocity = Speed * deltaTime;
            }
            //Otherwise stop and change direction
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }

        //Move one space right
        private void MoveRight(float deltaTime)
        {
            //Move right if the space is clear
            if (!CurrentScene.DetectCollision(Sprite.Right + Speed * deltaTime, YAbsolute))
            {
                XVelocity = Speed * deltaTime;
            }
            //Otherwise stop and change direction
            else
            {
                XVelocity = 0f;
                _facing++;
            }
        }

        //Move one space left
        private void MoveLeft(float deltaTime)
        {
            //Move left if the space is clear
            if (!CurrentScene.DetectCollision(Sprite.Left - Speed * deltaTime, YAbsolute))
            {
                XVelocity = -Speed * deltaTime;
            }
            //Otherwise stop and change direction
            else
            {
                XVelocity = 0f;
                _facing = Direction.North;
            }
        }

        //move one space up
        private void MoveUp(float deltaTime)
        {
            //Move up if the space is clear
            if (!CurrentScene.DetectCollision(XAbsolute, Sprite.Top - Speed * deltaTime))
            {
                YVelocity = -Speed * deltaTime;
            }
            //Otherwise change direction
            else
            {
                YVelocity = 0f;
                _facing++;
            }
        }
    }
}
