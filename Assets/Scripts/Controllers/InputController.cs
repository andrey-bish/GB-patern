using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.Modification;


namespace Asteroids
{
    internal class InputController: IUpdateble
    {
        #region Field

        private readonly Ship _ship;
        private readonly Camera _camera;
        private  IShooting _weapon;
        private readonly MainControllers _mainControllers;
        private readonly Data _data;
        
        #endregion


        #region Constructor

        public InputController(AccelerationMove moveTransform, RotationShip rotation, Camera camera, IShooting weapon, MainControllers mainControllers, Data data)
        {
            _ship = new Ship(moveTransform, rotation);
            _camera = camera;
            _weapon = weapon;
            _mainControllers = mainControllers;
            _mainControllers.Add(this);
            _data = data;
        }

        #endregion


        #region Methods

        public void SetWeapon(IShooting shooting)
        {
            _weapon = shooting;
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
                _weapon.Shooting();
            }
        }

        #endregion


        #region UnityMethods

        public void Updateble(float deltaTime)
        {
            CameraCursorTracking();
            CheckInputKey(deltaTime);
        }

        #endregion
    }
}
