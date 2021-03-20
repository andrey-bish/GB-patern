using System;


namespace Asteroids
{
    public class PlayerHealth
    {
        public event Action Death;
        private float _hp;

        public PlayerHealth(float HP)
        {
            _hp = HP;
        }

        public void Damage(float damagePoint)
        {
            _hp -= damagePoint;
            if(_hp <= 0)
            {
                Death?.Invoke();
            }
        }
    }
}
