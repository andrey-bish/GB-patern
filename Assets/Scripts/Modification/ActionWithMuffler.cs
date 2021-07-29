using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids.Modification
{
    class ActionWithMuffler
    {
        private ModificationWeapon _modificationWeapon;

        private bool isMuffler = false;

        public void InstallationRemovalMuffler(Data data, Transform playerTranform, IWeapon weapon)
        {
            SetResetMuffler(data, playerTranform, weapon);
        }

        private void SetResetMuffler(Data data, Transform playerTranform, IWeapon weapon)
        {
            if (!isMuffler)
            {
                isMuffler = !isMuffler;

                var muffler = new Muffler(data.Bullet.OneShotMufflerAudioClip, playerTranform, data.Bullet.MufflerPrefab, data.Bullet.VolumeFireOnMuffler);

                _modificationWeapon = new ModificationMuffler(data.Bullet, muffler, playerTranform);
                _modificationWeapon.ApplyModification(weapon);
            }
            else
            {
                isMuffler = !isMuffler;
                _modificationWeapon.CancelModification(weapon);
            }
        }
    }
}
