using UnityEngine;
using Asteroids.Enemy;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids
{
    public class PlayerInitialize: IInitialization, ICleanup
    {
        #region Fields

        private readonly MainControllers _mainControllers;
        private readonly Data _data;

        private Transform _playerTransform;
        private PlayerView _player;
        private IWeapon _weapon;
        private Health _health;
        private Camera _camera;

        #endregion


        #region Constructor

        public PlayerInitialize(Data data, MainControllers mainControllers)
        {
            _data = data;
            _mainControllers = mainControllers;
        }

        #endregion


        #region Method

        private void InitializePlayer(Health health)
        {
            _health = health;
            _player = Object.Instantiate(_data.Player.PlayerPrefab);
            _data.Player.PlayerGO = _player.gameObject;
            _player.SetHealth(_health);
            _health.OnDeath += _player.Death;

            _playerTransform = _player.transform;

            _camera = Camera.main;
            _camera.transform.position = _playerTransform.position + new Vector3(0, 0, _data.Player.CameraOffset);

            var moveTranform = new AccelerationMove(_playerTransform, _data.Player.Speed, _data.Player.Acceleration);
            var rotation = new RotationShip(_playerTransform);

            _weapon = new Weapon(_data, _playerTransform);

            var inputController = new InputController(moveTranform, rotation, _camera, _weapon, _mainControllers, _data, _playerTransform);
        }

        #endregion


        #region Unity Methods

        public void Initialization()
        {
            InitializePlayer(new Health(_data.Player.Hp));
        }        
        
        public void Cleanup()
        {
            _health.OnDeath -= _player.Death;
        }

        #endregion
    }
}
