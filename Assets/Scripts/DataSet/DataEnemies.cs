using UnityEngine;
using Asteroids.Enemy;

namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Enemies", menuName = "Data/EnemiesSettings")]
    public class DataEnemies : ScriptableObject
    {
        [Header("General Enemy parameters")]
        public float Speed;
        public float ImpulseStrenge;
        public float Hp;
        

        [Header("Comet View")]
        public CometView CometPrefab;
        public string CometKillPoint;

        [Header("Asteroid View")]
        public AsteroidView AsteroidPrefab;
        public string AsteroidKillPoint;

        [Header("EnemyShip View")]
        public EnemyShipView EnemyShipPrefab;
        public string EnemyShipKillPoint;
        public float RangeAtack;
    }
}
