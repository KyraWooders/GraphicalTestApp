using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        private Sword _sword { get; } = new Sword(33,0);
        private static Player _instance;

        Sprite _sprite;
        AABB _hitBox;

        public Player(float x, float y) : base(x, y)
        {
            OnUpdate += MoveRight;
            OnUpdate += MoveLeft;
            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            
            _instance = this;

            _sprite = new Sprite("gameAssets/cry.jpg");
            AddChild(_sprite);
            
            _hitBox = new AABB(_sprite.Width, _sprite.Height);
            AddChild(_hitBox);

            AddChild(_sword);

        }

        public static Player Instance
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

        //private void TouchEnemy(float deltaTime)
        //{
        //    if (Enemy.Instance.HitBox.DetectCollision(HitBox))
        //    {
        //        Parent.RemoveChild(this);
        //    }
        //}

        //Move one space to the right
        private void MoveRight(float deltaTime)
        {
            if (Input.IsKeyDown(68))//D
            {
                X += 100 * deltaTime;
            }
        }

        //move one space to the left
        private void MoveLeft(float deltaTime)
        {
            if (Input.IsKeyDown(65))//A
            {
                X -= 100 * deltaTime;
            }
        }

        private void MoveDown(float deltaTime)
        {
            if (Input.IsKeyDown(83))//S
            {
                Y += 100 * deltaTime;
            }
        }

        private void MoveUp(float deltaTime)
        {
            if (Input.IsKeyDown(87))//W
            {
                Y -= 100 * deltaTime;
            }
        }

        ////move the player to the destination room and change the Scene 
        //private void Travel(Room destination)
        //{
        //    //ensure destion is not null
        //    if (destination == null)
        //    {
        //        return;
        //    }
        //    //remove the player from its current room
        //    CurrentScene.RemoveChild(this);
        //    //add the player to the destination room
        //    destination.AddChild(this);
        //    //change the game's active snene to the destination
        //}
    }
}
