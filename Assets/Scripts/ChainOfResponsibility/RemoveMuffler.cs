using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.Modification
{
    class RemoveMuffler : WeaponModification
    {
        private Transform _playerTranform;

        public RemoveMuffler(IWeapon weapon, Transform playerTranform) : base(weapon)
        {
            _playerTranform = playerTranform;
            Object.Destroy(_playerTranform.Find("Muffler(Clone)").gameObject);
        }

        public override void Handle()
        {
            _weapon.SetBarrelPosition(_playerTranform.Find("Barrel"));
            base.Handle();
        }
    }
}
