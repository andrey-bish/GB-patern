using UnityEngine;

namespace Json
{
    class Mag : MonoBehaviour, IEnemy
    {
        [SerializeField] private float _health;
        public float health => _health;

        public void SetHealth(float health)
        {
            _health = health;
        }
    }
}
