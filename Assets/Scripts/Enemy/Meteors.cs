using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Meteors : MonoBehaviour, IDamageble
    {
        public void Damage(float damagePoint)
        {
            Debug.Log($"Damage {damagePoint}");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent<IDamageble>(out var damageble))
            {
                damageble.Damage(5.0f);
            }
        }
    }
}