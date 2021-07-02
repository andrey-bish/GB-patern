using UnityEngine;
using Asteroids.Enemy;

namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "Data/EnemiesSettings")]
    public class DataEnemies : ScriptableObject
    {
        public float Speed;
        public float Hp;
        public CometView CometPrefab;
        public AsteroidView AsteroidPrefab;
        public EnemyShipView EnemyShipPrefab;
    }
}
