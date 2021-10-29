using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.Modification
{
    sealed class ModificationMuffler : ModificationWeapon
    {

        #region Fields

        private readonly AudioSource _audioSource;
        private readonly Transform _playerTranform;
        private readonly DataWeapon _dataWeapon;
        private readonly IMuffler _muffler;

        private GameObject _mufflerGO;

        private readonly float _damage;
        private readonly float _shotVolumeMuffler;

        #endregion


        #region Constructor

        public ModificationMuffler(DataWeapon dataWeapon, IMuffler muffler, Transform playerTranform)
        {
            _dataWeapon = dataWeapon;
            _audioSource = playerTranform.GetComponent<AudioSource>();
            _muffler = muffler;
            _playerTranform = playerTranform;
            _damage = _dataWeapon.DamageWhitMuffler;
            _shotVolumeMuffler = _dataWeapon.ShotVolumeMuffler;
        }

        #endregion


        #region Methods

        protected override IWeapon AddModification(IWeapon weapon)
        {
            _mufflerGO = Object.Instantiate(_muffler.MufflerInstance, _playerTranform.Find("Barrel").position, _playerTranform.rotation);
            _mufflerGO.transform.parent = _playerTranform;
            SetNewParameters(weapon, _muffler.AudioClipMuffler, _damage, _shotVolumeMuffler, _mufflerGO.transform.Find("ShotLocation"));
            return weapon;
        }

        protected override IWeapon ResetModification(IWeapon weapon)
        {
            Object.Destroy(_mufflerGO);
            SetNewParameters(weapon, _dataWeapon.OneShotAudioClip, _dataWeapon.Damage, _dataWeapon.DefaultShotVolume, _playerTranform.Find("Barrel"));
            return weapon;
        }

        private void SetNewParameters(IWeapon weapon, AudioClip audioClip, float damage, float shotVolume, Transform shotLocation)
        {
            weapon.SetAudioClip(audioClip);
            weapon.SetDamage(damage);
            weapon.SetShotVolume(shotVolume);
            weapon.SetBarrelPosition(shotLocation);
        }

        #endregion

    }
}
