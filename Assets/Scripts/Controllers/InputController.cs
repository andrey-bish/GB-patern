using UnityEngine;


namespace Asteroids
{
    internal class InputController : IUpdateble
    {
        private Ship _ship;
        private Camera _camera;
        private Transform _player;
        private DataBullet _dataBullet;

        public InputController(AccelerationMove moveTransform, RotationShip rotation, Camera camera, Transform player, DataBullet dataBullet)
        {
            var ship = new Ship(moveTransform, rotation);
            _ship = ship;
            _camera = camera;
            _player = player;
            _dataBullet = dataBullet;
        }

        public void CameraCursorTracking()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_camera.transform.position);
            _ship.Rotation(direction);
        }

        public void CheckInputKey(float deltaTime)
        {
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), deltaTime);

            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if(Input.GetButtonDown("Fire1"))
            {
                var bullet = GameObject.Instantiate(_dataBullet.Bullet, _player.position, _player.rotation);
                bullet.AddForce(_player.up * _dataBullet.Force);
            }
        }


        public void Updateble(float deltaTime)
        {
                CheckInputKey(deltaTime);            
        }
    }
}
