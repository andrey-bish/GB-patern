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

        public void EnemyFlightDirection(IEnemy enemies)
        {
            var player = _dataPlayer.PlayerPrefab;
            if ((enemies as MonoBehaviour).GetComponent<EnemyShipView>())
            {
                SpawnGameObject((enemies as MonoBehaviour), player);
            }
            else
            {
                SpawnGameObject((enemies as MonoBehaviour), player);
                (enemies as MonoBehaviour).transform.up = player.transform.position - (enemies as MonoBehaviour).transform.position;
                (enemies as MonoBehaviour).GetComponent<Rigidbody2D>().AddForce((enemies as MonoBehaviour).transform.up * 2.0f, ForceMode2D.Impulse);
            }            
        }

        private void SpawnGameObject(MonoBehaviour enemies, GameObject player)
        {
            enemies.transform.position = new Vector2(
                   player.transform.position.x + Random.Range(_minSpawnRange, _maxSpawnRange),
                   player.transform.position.y + Random.Range(-_minSpawnRange, _maxSpawnRange));
        }
    }
}
