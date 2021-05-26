﻿using UnityEngine;
using Asteroids.Dataset;


namespace Asteroids
{
    internal class InputController : IUpdateble
    {
        private Ship _ship;
        private Camera _camera;
        private DataBullet _dataBullet;
        private Transform _barrel;

        public InputController(AccelerationMove moveTransform, RotationShip rotation, Camera camera, Transform player, DataBullet dataBullet)
        {
            var ship = new Ship(moveTransform, rotation);
            _barrel = player.GetChild(0);
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
                var bullet = GameObject.Instantiate(_dataBullet.Bullet, _barrel.position, _barrel.rotation);
                bullet.AddForce(_barrel.up * _dataBullet.Force);
                
                
            }
        }


        public void Updateble(float deltaTime)
        {
                CheckInputKey(deltaTime);            
        }
    }
}
