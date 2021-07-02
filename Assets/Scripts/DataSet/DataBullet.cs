using UnityEngine;

namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Data/BulletSettings")]
    public class DataBullet : ScriptableObject
    {
        public float Force;
        public GameObject BulletPref;
        public float Damage;
        public float FireCooldown;
    }
}
