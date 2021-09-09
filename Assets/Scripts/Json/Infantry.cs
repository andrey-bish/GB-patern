using UnityEngine;

namespace Json
{
    class Infantry : MonoBehaviour, IEnemy
    {
        [SerializeField] private float _health;
        public float health => _health;
        public void SetHealth(float health)
        {
            _health = health;
        }
    }
}
