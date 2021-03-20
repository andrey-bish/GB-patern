using UnityEngine;


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

        public void InitializeObj()
        {
            var player = GameObject.Instantiate(_data.Player.PlayerPrefab).transform;
            var camera = Camera.main;
            camera.transform.parent = player;

            var moveTranform = new AccelerationMove(player, _data.Player.Speed, _data.Player.Acceleration);
            var rotation = new RotationShip(player);

            //var bullet = GameObject.Instantiate(_data.Bullet.Bullet, player.position, player.rotation);

            _inputController = new InputController(moveTranform, rotation, camera, player, _data.Bullet);
        }


        public void Initialization()
        {
            InitializeObj();
        }

        public void Updateble(float deltaTime)
        {
            _inputController.CheckInputKey(deltaTime);
            _inputController.CameraCursorTracking();
        }
    }   
}
