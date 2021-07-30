using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids.Modification
{
    class ActionWithLaserAim: IUpdateble
    {
        #region Fields

        public bool IsLockedAim = false;
        public bool IsAim = true;

        private ModificationWeapon _modificationWeapon;
        private LineRenderer _playerLineRenderer;
        private Transform _playerTransform;

        private bool IsExistenceLaserAim = false;

        #endregion


        #region Constructor

        public ActionWithLaserAim(Transform playerTransform, MainControllers mainControllers)
        {
            mainControllers.Add(this);
            _playerLineRenderer = playerTransform.GetComponent<LineRenderer>();
            _playerTransform = playerTransform;
        }

        #endregion


        #region Methods

        public void ActionsOnTheLaserAim(DataWeapon dataWeapon, IWeapon weapon, Material material)
        {
            PickUpAndDropLaserAim(dataWeapon, weapon, material);
        }

        private void PickUpAndDropLaserAim(DataWeapon dataWeapon, IWeapon weapon, Material material)
        {
            //В идеале этот метод подписать на событие
            if(!IsExistenceLaserAim)
            {
                var aimLaser = new AimLaser(material);
                _modificationWeapon = new ModificationAimLaser(aimLaser, dataWeapon);
                _modificationWeapon.ApplyModification(weapon);
                IsExistenceLaserAim = true;
                IsAim = true;
            }
            else
            {
                _playerLineRenderer.enabled = false;
                _modificationWeapon.CancelModification(weapon);
                IsExistenceLaserAim = false;
            }
        }

        public void CheckStatusLaserAim()
        {
            if(IsExistenceLaserAim)
            {
                if (IsLockedAim)
                {
                    Debug.Log("U're LaserAim locked!");
                }
                else
                {
                    if (IsAim)
                    {
                        IsAim = !IsAim;
                        _playerLineRenderer.enabled = true;
                    }
                    else
                    {
                        IsAim = !IsAim;
                        _playerLineRenderer.enabled = false;
                    }
                }
            }
            else 
            {
                Debug.Log("U're have't LaserAim!");
            }            
        }

        private void DrawLine()
        {
            _playerLineRenderer.SetPosition(0, _playerTransform.Find("Aim").position);
            _playerLineRenderer.SetPosition(1, _playerTransform.Find("AimLength").position);
        }

        #endregion


        #region UnityMethods

        public void Updateble(float deltaTime)
        {
            if (!IsLockedAim && _playerLineRenderer.enabled && IsExistenceLaserAim)
            {
                DrawLine();
            }
            else
            {
                _playerLineRenderer.enabled = false;
            }
        }

        #endregion
    }
}
