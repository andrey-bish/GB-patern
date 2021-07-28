using UnityEngine;
using Asteroids.Enemy;
using Asteroids.Dataset;
using Asteroids.Interface;
using Asteroids.Modification;


namespace Asteroids
{
    public class PlayerInitialize:  IInitialization, IUpdateble
    {
        private Data _data;
        //private InputController _inputController;
        private MainControllers _mainControllers;
        private Weapon _weapon;
        private ModificationWeapon _modificationWeapon;

        private Transform _playerTranform;

        private bool isMuffler = false;

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
            //_inputController.CheckInputKey(deltaTime);
            //_inputController.CameraCursorTracking();
            if(Input.GetKeyDown(KeyCode.F))
            {
                if (!isMuffler)
                {
                    isMuffler = !isMuffler;

                    var muffler = new Muffler(_data.Bullet.OneShotMufflerAudioClip, _data.Bullet.VolumeFireOnMuffler, _playerTranform, _data.Bullet.MufflerPrefab);

                    _modificationWeapon = new ModificationMuffler(_data.Bullet, muffler, _playerTranform);
                    _modificationWeapon.ApplyModification(_weapon);
                }
                else
                {
                    isMuffler = !isMuffler;
                    _modificationWeapon.CancelModification(_weapon);
                }
            }
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

            var inputController = new InputController(moveTranform, rotation, camera, _weapon, _mainControllers, _data);

            //inputController.SetWeapon(modificationWeapon);


        }
    }   
}
