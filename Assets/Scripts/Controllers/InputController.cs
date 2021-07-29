using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.Modification;


namespace Asteroids
{
    internal class InputController: IUpdateble, IInitialization
    {
        #region Field

        private readonly Ship _ship;
        private readonly Camera _camera;
        private IWeapon _weapon;
        private readonly MainControllers _mainControllers;
        private readonly Data _data;
        private ActionWithMuffler _actionWithMuffler;
        private Transform _playerTranform;
        
        #endregion


        #region Constructor

        public InputController(AccelerationMove moveTransform, RotationShip rotation, Camera camera, IWeapon weapon, MainControllers mainControllers, Data data, Transform playerTranform)
        {
            _ship = new Ship(moveTransform, rotation);
            _camera = camera;
            _weapon = weapon;
            _mainControllers = mainControllers;
            _mainControllers.Add(this);
            _data = data;
            _playerTranform = playerTranform;
        }

        #endregion


        #region Methods

        //public void SetWeapon(IShooting shooting)
        //{
        //    _weapon = shooting;
        //}

        private void InteractionWithMuffler()
        {
            _actionWithMuffler.InstallationRemovalMuffler(_data, _playerTranform, _weapon);
        }

        private void CameraCursorTracking()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_camera.transform.position);
            _ship.Rotation(direction);
        }

        private void CheckInputKey(float deltaTime)
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
            if (Input.GetKeyDown(KeyCode.F))
            {
                InteractionWithMuffler();
            }
        }

        #endregion


        #region UnityMethods

        public void Updateble(float deltaTime)
        {
            CameraCursorTracking();
            CheckInputKey(deltaTime);
        }

        public void Initialization()
        {
            _actionWithMuffler = new ActionWithMuffler();
        }


        #endregion
    }
}
