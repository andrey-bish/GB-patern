using UnityEngine;


namespace Asteroids
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public class Data : ScriptableObject
    {
        [SerializeField] private DataPlayer _player;
        [SerializeField] private DataBullet _bullet;

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



    }
}
