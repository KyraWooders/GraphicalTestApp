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
        public List<Bullet> _bulletsfired = new List<Bullet>();

        //creates a new sword
        public Sword(float x, float y) : base(x, y)
        {
            _instance = this;

            _sprite = new Sprite("gameAssets/wizstaf.png");
            AddChild(_sprite);

            _hitBox = new AABB(_sprite.Width, _sprite.Height);
            AddChild(_hitBox);

            OnUpdate += RotateSword;
            OnUpdate += FireBullets;

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
            if (Input.IsKeyDown(76))
            {
                Rotate(1f * deltaTime);
            }
            if (Input.IsKeyDown(75))
            {
                Rotate(-1f * deltaTime);
            }
        }

        //fires a bullet with every tap of the space key if 
        private void FireBullets(float deltaTime)
        {
            if (Input.IsKeyPressed(32))//upkey
            {
                if (_bulletsfired.Count >= 15)
                {
                    Parent.Parent.RemoveChild(_bulletsfired[0]);
                    _bulletsfired.Remove(_bulletsfired[0]);
                }
                Bullet bullet = new Bullet(Player.Instance.X + 66, Player.Instance.Y);
                _bulletsfired.Add(bullet);
                Parent.Parent.AddChild(bullet);
                Vector3 direction = GetDirectionAbsolute();
                direction *= 80;
                bullet.XVelocity = direction.x;
                bullet.YVelocity = direction.y;
            }
        }

    }
}
