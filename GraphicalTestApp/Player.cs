using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Player : Entity
    {
        private Sword _sword { get; } = new Sword(66,0);
        private static Player _instance;
        public List<Bullet> _bulletsfired = new List<Bullet>();
        
        Sprite _sprite;
        AABB _hitBox;




        //creates a new player
        public Player(float x, float y) : base(x, y)
        {
            OnUpdate += MoveRight;
            OnUpdate += MoveLeft;
            OnUpdate += MoveUp;
            OnUpdate += MoveDown;
            OnUpdate += FireBulletUp;
            OnUpdate += FireBulletDown;

            _instance = this;

            _sprite = new Sprite("gameAssets/aaa.png");
            AddChild(_sprite);
            
            _hitBox = new AABB(_sprite.Width, _sprite.Height);
            AddChild(_hitBox);

            AddChild(_sword);
            
        }

        //getting an instance of the player
        public static Player Instance
        {
            get
            {
                return _instance;
            }
        }

        //getting an instance to the player's hitbox
        public AABB HitBox
        {
            get
            {
                return _hitBox;
            }
        }
        
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

        //move one space down
        private void MoveDown(float deltaTime)
        {
            if (Input.IsKeyDown(83))//S
            {
                Y += 100 * deltaTime;
            }
        }
        
        //move one space up
        private void MoveUp(float deltaTime)
        {
            if (Input.IsKeyDown(87))//W
            {
                Y -= 100 * deltaTime;
            }
        }

        private void FireBulletUp(float deltaTime)
        {
            if (Input.IsKeyPressed(265))//upkey
            {
                if (_bulletsfired.Count >= 5)
                {
                    Parent.RemoveChild(_bulletsfired[0]);
                    _bulletsfired.Remove(_bulletsfired[0]);
                }
                Bullet bullet = new Bullet(this.X, this.Y);
                _bulletsfired.Add(bullet);
                Parent.AddChild(bullet);
                bullet.MoveUp(deltaTime);
            }
        }

        private void FireBulletDown(float deltaTime)
        {
            if (Input.IsKeyPressed(264))//downkey
            {
                if (_bulletsfired.Count >= 5)
                {
                    Parent.RemoveChild(_bulletsfired[0]);
                    _bulletsfired.Remove(_bulletsfired[0]);
                }
                Bullet bullet = new Bullet(this.X, this.Y);
                _bulletsfired.Add(bullet);
                Parent.AddChild(bullet);
                bullet.MoveDown(deltaTime);
            }
           
        }
    }
}
