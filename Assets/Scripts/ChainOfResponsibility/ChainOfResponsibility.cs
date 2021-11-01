using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Interface;

namespace Asteroids.Modification
{
    class ChainOfResponsibility
    {
        private readonly IWeapon _weapon;

        private WeaponModification _weaponModification;

        private bool _isMuffler;
        
        public ChainOfResponsibility()
        {
            _weaponModification = new WeaponModification(_weapon);
            _isMuffler = new ActionWithMuffler().isMuffler;
        }

        public void InstallationRemovalMuffler(Transform playerTransform, DataWeapon dataWeapon, IWeapon weapon)
        {

            if (!_isMuffler)
            {
                InstallationMuffler(playerTransform, dataWeapon, weapon);
            }
            else
            {
                RmoveMuffler(playerTransform, dataWeapon, weapon);
            }
        }

        private void InstallationMuffler(Transform playerTransform, DataWeapon dataWeapon, IWeapon weapon)
        {
            _isMuffler = true;
            _weaponModification.Add(new EditAttackModification(weapon, 100.0f));
            _weaponModification.Add(new EditAudioClip(weapon, dataWeapon.OneShotMufflerAudioClip));
            _weaponModification.Add(new EditAudioVolume(weapon, dataWeapon.ShotVolumeMuffler));
            _weaponModification.Add(new AddMuffler(weapon, dataWeapon, playerTransform));
            _weaponModification.Handle();
        }

        private void RmoveMuffler(Transform playerTransform, DataWeapon dataWeapon, IWeapon weapon)
        {
            _isMuffler = false;
            _weaponModification.Add(new EditAttackModification(weapon, dataWeapon.Damage));
            _weaponModification.Add(new EditAudioClip(weapon, dataWeapon.OneShotAudioClip));
            _weaponModification.Add(new EditAudioVolume(weapon, dataWeapon.DefaultShotVolume));
            _weaponModification.Add(new RemoveMuffler(weapon, playerTransform));
            _weaponModification.Handle();
        }
    }
}
