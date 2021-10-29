using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;

namespace Asteroids.Modification
{
    class RemoveMuffler : WeaponModification
    {
        private GameObject _mufflerGO;
        private Transform _playerTranform;


        public RemoveMuffler(IWeapon weapon, DataWeapon dataWeapon, Transform playerTranform) : base(weapon)
        {

            //var muffler = new Muffler(dataWeapon.OneShotMufflerAudioClip, playerTranform, dataWeapon.MufflerPrefab, dataWeapon.ShotVolumeMuffler);
            //_mufflerGO.transform = playerTranform.Find("Muffler");
            _playerTranform = playerTranform;
            //_mufflerGO = new AddMuffler(weapon, dataWeapon, playerTranform)._mufflerGO;
            //_mufflerGO = GameObject.Find("Muffler");
            Object.Destroy(GameObject.Find("Muffler"));
            
            
        }

        public override void Handle()
        {
            _weapon.SetBarrelPosition(_playerTranform.Find("Barrel"));
            base.Handle();
        }
    }
}
