using UnityEngine;


namespace Asteroids.Interface
{
    interface IWeapon: IShooting
    {
        void SetAudioClip(AudioClip audioClip);

        void SetBarrelPosition(Transform barrelPosition);

        void SetDamage(float damage);

        void SetAimLaser(Material aimLaserMaterial);

        void SetWeaponLockeD(bool isWeaponLocked);

    }
}
