using UnityEngine;


namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private DataPlayer _player;
        [SerializeField] private DataBullet _bullet;
        [SerializeField] private DataEnemies _enemies;

        public DataPlayer Player
        {
            get => _player;
            set => _player = value;
        }
        
        public DataBullet Bullet
        {
            get => _bullet;
            set => _bullet = value;
        }

        public DataEnemies Enemies
        {
            get => _enemies;
            set => _enemies = value;
        }

    }
}
