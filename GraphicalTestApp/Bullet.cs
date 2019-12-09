using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Bullet : Entity
    {
        public float Speed { get; set; } = 160f;
        Sprite _sprite;
        AABB _hitBox;
        private List<Enemy> _removals;

        //creates a new bullet
        public Bullet(float x, float y) : base(x, y)
        {
            _removals = new List<Enemy>();
            _sprite = new Sprite("gameAssets/bullet.png");
            AddChild(_sprite);

            _hitBox = new AABB(_sprite.Width, _sprite.Height);
            AddChild(_hitBox);
        }

        //getting an instance to the bullet's hitbox
        public AABB HitBox
        {
            get
            {
                return _hitBox;
            }
        }

        //if the Enemy has touched the enemies, remove itself and the enemey
        private void TouchEnemy(float deltaTime)
        {
            foreach(Enemy e in _removals)
            {
                if(Program.Enemies.Contains(e))
                {
                    Program.Enemies.Remove(e);
                }
            }
            foreach (Enemy e in Program.Enemies)
            {
                if (HitBox.DetectCollision(e.HitBox) && e.Parent != null)
                {
                    e.Parent.RemoveChild(e);
                    Parent.RemoveChild(this);
                    _removals.Add(e);
                }
            }
        }

        //have the bullet update before the enemy
        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            TouchEnemy(deltaTime);
        }

    }
}
