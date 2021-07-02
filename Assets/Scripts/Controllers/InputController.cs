using UnityEngine;
using Asteroids.Dataset;
using Asteroids.ObjectPool;
using Asteroids.Interface;


namespace Asteroids
{
    internal class InputController: IShooting
    {
        private Ship _ship;
        private Camera _camera;
        private DataBullet _dataBullet;
        private Transform _barrelPlayer;
        private float _lastFireTime = 0.0f;

        public InputController(AccelerationMove moveTransform, RotationShip rotation, Camera camera, Transform player, DataBullet dataBullet)
        {
            var ship = new Ship(moveTransform, rotation);
            _barrelPlayer = player.GetChild(0);
            _ship = ship;
            _camera = camera;
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
                Shooting();
            }
        }

        public void Shooting()
        {
            if (_lastFireTime + _dataBullet.FireCooldown < Time.time)
            {
                _lastFireTime = Time.time;
                var bullet = BulletObjectPool.GetBullet(_dataBullet.BulletPref, _barrelPlayer.position, _dataBullet.Damage);
                bullet.AddForce(_barrelPlayer.up * _dataBullet.Force, ForceMode2D.Impulse);
            }
        }
    }
}
