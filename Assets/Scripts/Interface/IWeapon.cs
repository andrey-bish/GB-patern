using UnityEngine;


namespace Asteroids.Interface
{
    interface IWeapon: IShooting
    {
        void SetAudioClip(AudioClip audioClip);

        void SetBarrelPosition(Transform barrelPosition);

        void SetDamage(float damage);

        void SetShotVolume(float shotVolume);

        void SetAimLaser(Material aimLaserMaterial);

        void SetWeaponLocked(bool isWeaponLocked);

        void SetFireFireCooldown(float fireCooldown);

    }
}
