using UnityEngine;
using Asteroids.Interface;

namespace Asteroids.Modification
{
    class Lockers
    {
        private bool _isWeaponLocked = false;

        public bool IsLocker(bool value)
        {
            value = !value;
            return value;
        }
    }
}
