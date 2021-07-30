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
        private readonly DataWeapon _dataBullet;
        private readonly IMuffler _muffler;

        private GameObject _mufflerGO;

        private readonly float _damage;

        #endregion


        #region Constructor

        public ModificationMuffler(DataWeapon dataBullet, IMuffler muffler, Transform playerTranform)
        {
            _dataBullet = dataBullet;
            _audioSource = _dataBullet.AudioSourcePlayer;
            _muffler = muffler;
            _playerTranform = playerTranform;
            _damage = _dataBullet.DamageWhitMuffler;
        }

        #endregion


        #region Methods

        protected override IWeapon AddModification(IWeapon weapon)
        {
            _mufflerGO = Object.Instantiate(_muffler.MufflerInstance, _playerTranform.Find("Barrel").position, _playerTranform.rotation);
            _mufflerGO.transform.parent = _playerTranform;
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            SetNewParameters(weapon, _muffler.AudioClipMuffler, _damage, _mufflerGO.transform.Find("ShotLocation"));
            return weapon;
        }

        protected override IWeapon ResetModification(IWeapon weapon)
        {
            Object.Destroy(_mufflerGO);
            SetNewParameters(weapon, _dataBullet.OneShotAudioClip, _dataBullet.Damage, _playerTranform.Find("Barrel"));
            return weapon;
        }

        private void SetNewParameters(IWeapon weapon, AudioClip audioClip, float damage, Transform shotLocation)
        {
            weapon.SetAudioClip(audioClip);
            weapon.SetDamage(damage);
            weapon.SetBarrelPosition(shotLocation);
        }

        #endregion

    }
}
