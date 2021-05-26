using UnityEngine;
using Asteroids.Dataset;

namespace Asteroids.Enemy
{
    public abstract class Enemy: MonoBehaviour
    {
        public Health Health { get; private set; }

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Unit/Asteroid"));

            enemy.Health = hp;

            return enemy; 
        }
    }
}
