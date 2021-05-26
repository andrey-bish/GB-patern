using Asteroids.Interface;
using System;
using UnityEngine;

namespace Asteroids.Enemy
{
    public class Asteroid : Enemy, IHit
    {
        public event Action<float> OnHitChange = delegate (float f) { };

        public void Hit(float damage)
        {
            Debug.Log($"Damage {damage}");
            OnHitChange.Invoke(damage);


            //Hp -= damage;
            //if (Hp <= 0)
            //{
            //    Destroy(gameObject);
            //}
        }
    }
}
