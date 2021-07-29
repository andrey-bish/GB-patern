using UnityEngine;
using Asteroids.Enemy;

namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "Data/EnemiesSettings")]
    public class DataEnemies : ScriptableObject
    {
        [Header("Enemy parameters")]
        public float Speed;
        public float ImpulseStrenge;
        public float Hp;
        public float RangeAtack;

        [Header("Enemie View")]
        public CometView CometPrefab;
        public AsteroidView AsteroidPrefab;
        public EnemyShipView EnemyShipPrefab;
    }
}
