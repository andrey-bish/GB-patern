using UnityEngine;
using Asteroids.Enemy;
using Asteroids.Dataset;
using Asteroids.Interface;

namespace Asteroids
{
    public class PlayerInitialize: IInitialization, IUpdateble, ICleanup
    {
        private MainControllers _mainControllers;
        private LineRenderer _lineRenderer;
        private IWeapon _weapon;
        private Data _data;
        private PlayerView _player;
        private Health _health;
        private Camera _camera;
        
        private Transform _playerTranform;

        public PlayerInitialize(Data data, MainControllers mainControllers)
        {
            _data = data;
            _mainControllers = mainControllers;
        }

        public void Initialization()
        {
            InitializeObj(new Health(_data.Player.Hp));
        }

        //убрать отсюда _inputController, перенести в отдельный контроллер, камеру инициализировать в GM.
        //player убрать в отдельный класс, чтобы передесть _inputContorller'у в GM
        private void InitializeObj(Health health)
        {
            _health = health;
            _player = Object.Instantiate(_data.Player.PlayerPrefab);
            _data.Player.PlayerGO = _player.gameObject;
            _player.SetHealth(_health);
            _health.OnDeath += _player.Death;
            
            _playerTranform = _player.transform;
            _lineRenderer = _playerTranform.GetComponent<LineRenderer>();

            _camera = Camera.main;
            _camera.transform.position = _playerTranform.position + new Vector3(0, 0, _data.Player.CameraOffset);

            var moveTranform = new AccelerationMove(_playerTranform, _data.Player.Speed, _data.Player.Acceleration);
            var rotation = new RotationShip(_playerTranform);

            _weapon = new Weapon(_data, _playerTranform);

            var inputController = new InputController(moveTranform, rotation, _camera, _weapon, _mainControllers, _data, _playerTranform);
        }
        public void Updateble(float deltaTime)
        {
            _camera.transform.position = _playerTranform.position + new Vector3(0, 0, _data.Player.CameraOffset);
        }
        
        public void Cleanup()
        {
            _health.OnDeath -= _player.Death;
        }

        
    }   
}
