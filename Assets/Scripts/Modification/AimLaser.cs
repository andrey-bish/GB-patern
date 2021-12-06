using Asteroids.Interface;
using UnityEngine;


namespace Asteroids.Modification
{
    class AimLaser : IAimLaser
    {
        public Material ViewAimLaser { get; }

        public AimLaser(Material viewAimLaser)
        {
            ViewAimLaser = viewAimLaser;
        }
    }
}
