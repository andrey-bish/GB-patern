using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;

namespace Asteroids.Modification
{
    class AddMuffler : WeaponModification
    {
        public GameObject _mufflerGO;


        public AddMuffler(IWeapon weapon, DataWeapon dataWeapon, Transform playerTranform) : base(weapon)
        {

            var muffler = new Muffler(dataWeapon.OneShotMufflerAudioClip, playerTranform, dataWeapon.MufflerPrefab, dataWeapon.ShotVolumeMuffler);
            _mufflerGO = Object.Instantiate(muffler.MufflerInstance, playerTranform.Find("Barrel").position, playerTranform.rotation);
            _mufflerGO.transform.parent = playerTranform;
        }

        public override void Handle()
        {
            _weapon.SetBarrelPosition(_mufflerGO.transform.Find("ShotLocation"));
            base.Handle();
        }
    }
}
