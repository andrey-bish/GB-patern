using UnityEngine;

namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Player", menuName = "Data/PlayerSettings")]
    public class DataPlayer : ScriptableObject
    {
        [Header("Camera")]
        public Camera Camera;
        public float CameraOffset;

        [Header("Player parametrs")]
        public float Speed;
        public float Acceleration;
        public float Hp;
        public float TimeRecording;

        [Header("Player prefab")]
        public PlayerView PlayerPrefab;
        public GameObject PlayerGO;
    }
}
