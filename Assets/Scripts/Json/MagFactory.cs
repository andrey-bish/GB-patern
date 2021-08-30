using UnityEngine;

namespace Json
{
    class MagFactory
    {
       public IEnemy Create(float health)
        {
            var enemy = GameObject.Instantiate(Resources.Load<Mag>("JsonPrefab/Mag"));
            enemy.SetHealth(health);
            return enemy;
        }
    }
}
