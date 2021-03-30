using System;

namespace Assets.Scripts.Interface
{
    public interface IHit
    {
        event Action<float> OnHitChange;
        void Hit(float damage);
    }
}
