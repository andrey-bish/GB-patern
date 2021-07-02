using UnityEngine;
using Asteroids.Enemy;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids
{
    public class PlayerInitialize:  IInitialization, IUpdateble
    {
        private Data _data;
        private InputController _inputController;

        public PlayerInitialize(Data data)
        {
            _data = data;
        }

        public void Initialization()
        {
            InitializeObj(new Health(_data.Player.Hp));
        }

        public void Updateble(float deltaTime)
        {
            _inputController.CheckInputKey(deltaTime);
            _inputController.CameraCursorTracking();
        }

        //убрать отсюда _inputController, перенести в отдельный контроллер, камеру инициализировать в GM.
        //player убрать в отдельный класс, чтобы передесть _inputContorller'у в GM
        public void InitializeObj(Health health)
        {
            var player = Object.Instantiate(_data.Player.PlayerPrefabScript);
            player.SetHealth(health);
            health.Death += player.Death;

            var playerTransform = player.transform;
            var camera = Camera.main;
            camera.transform.parent = playerTransform;

            var moveTranform = new AccelerationMove(playerTransform, _data.Player.Speed, _data.Player.Acceleration);
            var rotation = new RotationShip(playerTransform);


            //var bullet = GameObject.Instantiate(_data.Bullet.Bullet, player.position, player.rotation);


            _inputController = new InputController(moveTranform, rotation, camera, playerTransform, _data.Bullet);
        }
    }   
}
