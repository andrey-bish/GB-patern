using UnityEngine;


namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Data/BulletSettings")]
    public class DataBullet : ScriptableObject
    {
        public AudioSource AudioSourcePlayer;
        
        [Header("Start Gun")]
        public GameObject BulletPrefab;
        public AudioClip OneShotAudioClip;
        public float Force;
        public float Damage;
        public float FireCooldown;

        [Header("Muffler")]
        public GameObject MufflerPrefab;
        public AudioClip OneShotMufflerAudioClip;
        public float VolumeFireOnMuffler;
        public float DamageWhitMuffler;
        

    }
}
