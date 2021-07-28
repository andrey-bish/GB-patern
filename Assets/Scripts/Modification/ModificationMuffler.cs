using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.Modification
{
    sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Transform _playerTranform;
        private GameObject _mufflerGO;
        private readonly float _damage;
        private readonly DataBullet _dataBullet;

        public ModificationMuffler(DataBullet dataBullet, IMuffler muffler, Transform playerTranform)
        {
            _dataBullet = dataBullet;
            _audioSource = _dataBullet.AudioSourcePlayer;
            _muffler = muffler;
            _playerTranform = playerTranform;
            _damage = _dataBullet.DamageWhitMuffler;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            _mufflerGO = Object.Instantiate(_muffler.MufflerInstance, _playerTranform.Find("Barrel").position, _playerTranform.rotation);
            _mufflerGO.transform.parent = _playerTranform;
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetDamage(_damage);
            weapon.SetBarrelPosition(_mufflerGO.transform.Find("ShotLocation"));
            return weapon;
        }

        protected override Weapon ResetModification(Weapon weapon)
        {
            Object.Destroy(_mufflerGO);
            weapon.DefaultAudioClip(_dataBullet.OneShotAudioClip);
            weapon.DefaultDamage(_dataBullet.Damage);
            weapon.DefaultBarrelPosition(_playerTranform.Find("Barrel"));
            return weapon;
        }
    }
}
