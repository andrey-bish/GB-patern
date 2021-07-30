using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.Modification;


namespace Asteroids
{
    internal class InputController: IUpdateble, IInitialization
    {
        #region Field

        private readonly MainControllers _mainControllers;
        private readonly Transform _playerTranform;
        private readonly Camera _camera;
        private readonly Ship _ship;
        private readonly Data _data;

        private ActionWithLaserAim _actionWithLaserAim;
        private ActionWithMuffler _actionWithMuffler;
       
        private IWeapon _weapon;

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


        #region UnityMethods

        public void Updateble(float deltaTime)
        {
            CameraCursorTracking();
            CheckInputKey(deltaTime);
        }

        public void Initialization()
        {
            _actionWithLaserAim = new ActionWithLaserAim(_playerTranform, _mainControllers);
            _actionWithMuffler = new ActionWithMuffler();
        }

        #endregion


        #region Methods

        private void InteractionWithMuffler()
        {
            //Вот так глушитель можно надеть, но вот снять его уже не получится
            //new ActionWithMuffler().InstallationRemovalMuffler(_data, _playerTranform, _weapon);

            //А так уже всё нормально работает
            _actionWithMuffler.InstallationRemovalMuffler(_data, _playerTranform, _weapon);
        }

        private void InteractionWithLaserAim(Material viewLaserAim)
        {
            _actionWithLaserAim.ActionsOnTheLaserAim(_data.Weapon, _weapon, viewLaserAim);
        }

        private void CameraCursorTracking()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_camera.transform.position);
            _ship.Rotation(direction);
        }

        private void CheckInputKey(float deltaTime)
        {
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                _weapon.Shooting();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                InteractionWithMuffler();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                _actionWithLaserAim.CheckStatusLaserAim();
            }
            if(Input.GetKeyDown(KeyCode.I))
            {
                //симуляция залочки стрельбы
                _data.Weapon.IsWeaponLocked = !_data.Weapon.IsWeaponLocked;
                _weapon.SetWeaponLockeD(_data.Weapon.IsWeaponLocked);
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                //симуляция залочки прицела
                _actionWithLaserAim.IsLockedAim = !_actionWithLaserAim.IsLockedAim;
                _actionWithLaserAim.IsAim = true;
            }
            if(Input.GetKeyDown(KeyCode.U))
            {
                //симуляция подбора и потери лазерного прицела
                InteractionWithLaserAim(_data.Weapon.RedLaserAim);
            }
        }

        #endregion
    }
}
