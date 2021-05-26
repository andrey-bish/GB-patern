using UnityEngine;

namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "Data/EnemiesSettings")]
    public class DataEnemies : ScriptableObject
    {
        public float Speed;
        public float Hp;
        public GameObject AsteroidPrefab;
        public GameObject MeteoritPrefab;
    }
}
