using System;

namespace Asteroids.Interface
{
    public interface IHit
    {
        event Action<float> OnHitChange;
        void Hit(float damage);
    }
}
