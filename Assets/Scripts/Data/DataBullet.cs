using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu(fileName = "Bullet", menuName = "Data/BulletSettings")]
    public class DataBullet : ScriptableObject
    {
        public Rigidbody2D Bullet;
        public float Force;
    }
}
