using UnityEngine;

namespace Json
{
    class InfantryFactory
    {
        public IEnemy Create(float health)
        {
            var enemy = GameObject.Instantiate(Resources.Load<Infantry>("JsonPrefab/Infantry"));
            enemy.SetHealth(health);
            return enemy;
        }
    }
}
