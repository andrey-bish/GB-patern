using UnityEngine;


namespace Asteroids.Interface
{
    interface IWeapon: IShooting
    {
        void SetAudioClip(AudioClip audioClip);

        void SetBarrelPosition(Transform barrelPosition);

        void SetDamage(float damage);


        //void DefaultBarrelPosition(Transform barrelPosition);

        //void DefaultAudioClip(AudioClip audioClip);

        //void DefaultDamage(float damage);

    }
}
