using UnityEngine;
using Asteroids.Interface;
using System;

namespace Asteroids.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemy, IHit
    {
        public float Hp = 40.0f;

        public event Action<float> OnHitChange = delegate (float f) { };

        public void Hit(float damage)
        {
            Debug.Log($"Damage {damage}");
            OnHitChange.Invoke(damage);


            Hp -= damage;
            if (Hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void TestingMethod()
        {
            throw new System.NotImplementedException();
        }
    }
}
