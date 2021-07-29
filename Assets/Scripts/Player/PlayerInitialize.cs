using UnityEngine;
using Asteroids.Enemy;
using Asteroids.Dataset;
using Asteroids.Interface;
using Asteroids.Modification;


namespace Asteroids
{
    public class PlayerInitialize:  IInitialization, IUpdateble
    {
        private MainControllers _mainControllers;
        //private InputController _inputController;
        private IWeapon _weapon;
        private Data _data;
        
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

        public void Updateble(float deltaTime)
        {
            
        }

        //убрать отсюда _inputController, перенести в отдельный контроллер, камеру инициализировать в GM.
        //player убрать в отдельный класс, чтобы передесть _inputContorller'у в GM
        public void InitializeObj(Health health)
        {
            var player = Object.Instantiate(_data.Player.PlayerPrefab);
            player.SetHealth(health);
            health.Death += player.Death;

            _playerTranform = player.transform;

            var camera = Camera.main;
            camera.transform.parent = _playerTranform;

            var moveTranform = new AccelerationMove(_playerTranform, _data.Player.Speed, _data.Player.Acceleration);
            var rotation = new RotationShip(_playerTranform);

            _weapon = new Weapon(_data, _playerTranform);

            var inputController = new InputController(moveTranform, rotation, camera, _weapon, _mainControllers, _data, _playerTranform);

            //inputController.SetWeapon(modificationWeapon);


        }
    }   
}
