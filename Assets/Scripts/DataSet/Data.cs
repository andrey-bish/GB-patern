using UnityEngine;


namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private DataPlayer _player;
        [SerializeField] private DataWeapon _weapon;
        [SerializeField] private DataEnemies _enemies;

        public DataPlayer Player
        {
            get => _player;
            set => _player = value;
        }
        
        public DataWeapon Weapon
        {
            get => _weapon;
            set => _weapon = value;
        }

        public DataEnemies Enemies
        {
            get => _enemies;
            set => _enemies = value;
        }

    }
}
