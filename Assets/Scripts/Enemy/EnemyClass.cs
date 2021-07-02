using UnityEngine;

namespace Asteroids.Enemy
{
    public abstract class EnemyClass: MonoBehaviour
    {
        public Health Health { get; private set; }

        public static AsteroidStatic CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<AsteroidStatic>("Unit/Asteroid"));
            enemy.SetHealth(hp);
            hp.Death += enemy.Death;
            return enemy; 
        }
    }
}
