using UnityEngine;
using Assets.Scripts.Interface;


namespace Assets.Scripts
{
    class ListenerHitShowDamage
    {
        public void Add(IHit value)
        {
            value.OnHitChange += ValueOnHitChange;
        }

        public void Remove(IHit value)
        {
            value.OnHitChange -= ValueOnHitChange;
        }

        private void ValueOnHitChange(float damage)
        {
            Debug.Log(damage);
        }
    }
}
