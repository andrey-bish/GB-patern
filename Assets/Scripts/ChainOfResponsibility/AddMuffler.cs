using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.Modification
{
    class AddMuffler : WeaponModification
    {
        private Transform _playerTransform;
        public GameObject _mufflerGO;
        

        public AddMuffler(IWeapon weapon, DataWeapon dataWeapon, Transform playerTransform) : base(weapon)
        {
            _playerTransform = playerTransform;
            var muffler = new Muffler(dataWeapon.OneShotMufflerAudioClip, playerTransform, dataWeapon.MufflerPrefab, dataWeapon.ShotVolumeMuffler);
            _mufflerGO = Object.Instantiate(muffler.MufflerInstance, playerTransform.Find("Barrel").position, playerTransform.rotation);
             _mufflerGO.transform.parent = playerTransform;
        }

        public override void Handle()
        {
            if(_mufflerGO == null)
               _weapon.SetBarrelPosition(_playerTransform.Find("Muffler(Clone)").GetChild(0));
            else
                _weapon.SetBarrelPosition(_mufflerGO.transform.Find("ShotLocation"));
            
            base.Handle();
        }
    }
}
