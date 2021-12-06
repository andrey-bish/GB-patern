using UnityEngine;


namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Data/WeaponSettings")]
    public class DataWeapon : ScriptableObject
    {
        public AudioSource AudioSourcePlayer;
        
        [Header("Start Gun")]
        public GameObject BulletPrefab;
        public AudioClip OneShotAudioClip;
        public float Force;
        public float Damage;
        public float DefaultShotVolume;
        public float FireCooldown;
        public bool IsWeaponLocked;

        [Header("Muffler")]
        public GameObject MufflerPrefab;
        public AudioClip OneShotMufflerAudioClip;
        public float ShotVolumeMuffler;
        public float DamageWhitMuffler;

        [Header("Laser Aim Type")]
        public Material DefaultLaserAim;
        public Material RedLaserAim;
    }
}
