using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interface;
using System;

namespace Assets.Scripts.Enemy
{
    public class Meteors : MonoBehaviour, IDamageble, IHit
    {
        public event Action<float> OnHitChange = delegate(float f) { };


        public void Damage(float damagePoint)
        {
            Debug.Log($"Damage {damagePoint}");
        }

        public void Hit(float damage)
        {
            Debug.Log("quqa");
            OnHitChange.Invoke(damage);
        }


        //private void OnCollisionEnter2D(Collision2D collision)
        //{
        //    if (collision.gameObject.TryGetComponent<IDamageble>(out var damageble))
        //    {
        //        damageble.Damage(5.0f);
        //    }
        //}
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
            
        //}
    }
}