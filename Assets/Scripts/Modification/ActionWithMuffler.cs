using UnityEngine;
using Asteroids.Dataset;


namespace Asteroids.Modification
{
    class ActionWithMuffler
    {
        private ModificationWeapon _modificationWeapon;

        private bool isMuffler = false;

        public void Doit(Data data, Transform playerTranform, Weapon weapon)
        {
            SetResetMuffler(data, playerTranform, weapon);
        }

        private void SetResetMuffler(Data data, Transform playerTranform, Weapon weapon)
        {
            if (!isMuffler)
            {
                isMuffler = !isMuffler;

                var muffler = new Muffler(data.Bullet.OneShotMufflerAudioClip, data.Bullet.VolumeFireOnMuffler, playerTranform, data.Bullet.MufflerPrefab);

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
