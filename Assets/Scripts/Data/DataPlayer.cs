using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/PlayerSettings")]
    public class DataPlayer : ScriptableObject
    {
        public float Speed;
        public float Acceleration;
        public float Hp;
        public GameObject PlayerPrefab;
    }
}
