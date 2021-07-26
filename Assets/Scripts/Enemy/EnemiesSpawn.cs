using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Interface;

namespace Asteroids.Enemy
{
    public class EnemiesSpawn
    {
        private DataPlayer _dataPlayer;

        private const float _minSpawnRange = -5.0f;
        private const float _maxSpawnRange = 5.0f;

        public EnemiesSpawn(DataPlayer dataPlayer)
        {
            _dataPlayer = dataPlayer;
        }

        public void RandomSpawnLocation(IEnemy enemies)
        {
            (enemies as MonoBehaviour).transform.position = new Vector2(
                   _dataPlayer.PlayerPrefab.transform.position.x + Random.Range(_minSpawnRange, _maxSpawnRange),
                   _dataPlayer.PlayerPrefab.transform.position.y + Random.Range(_minSpawnRange, _maxSpawnRange));          
        }

    }
}
