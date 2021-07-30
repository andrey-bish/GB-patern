using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids.Modification
{
    class ActionWithMuffler
    {
        private ModificationWeapon _modificationWeapon;

        public bool isMuffler = false;

        public void InstallationRemovalMuffler(Data data, Transform playerTranform, IWeapon weapon)
        {
            SetResetMuffler(data, playerTranform, weapon);
        }

        private void SetResetMuffler(Data data, Transform playerTranform, IWeapon weapon)
        {
            if (!isMuffler)
            {
                isMuffler = !isMuffler;

                var muffler = new Muffler(data.Weapon.OneShotMufflerAudioClip, playerTranform, data.Weapon.MufflerPrefab, data.Weapon.VolumeFireOnMuffler);

                _modificationWeapon = new ModificationMuffler(data.Weapon, muffler, playerTranform);
                _modificationWeapon.ApplyModification(weapon);
            }
            
            else if (isMuffler)
            {
                isMuffler = !isMuffler;
                _modificationWeapon.CancelModification(weapon);
            }
        }
    }
}
