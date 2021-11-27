using UnityEngine;
using System.Collections.Generic;
using Asteroids.Interface;
using Asteroids.Dataset;
using Asteroids.Models;


namespace Asteroids.UI
{
    class InputUIController : IUpdateble
    {
        #region Fields

        public readonly Stack<StateUI> _stateUIStack = new Stack<StateUI>();

        private HealthBarInterface _healthBarInterface;

        #endregion


        #region Constructor

        public InputUIController(MainControllers mainControllers, GameObject mainUI, Data data)
        {
            data.UI.LinkToMainUI = mainUI;
            _healthBarInterface = new HealthBarInterface(mainControllers, mainUI, data);
            _stateUIStack = _healthBarInterface.StateUIStack;
            mainControllers.Add(this);
        }

        #endregion


        #region UnityMethods

        public void Updateble(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                _healthBarInterface.Execute(StateUI.HealthBarUIWhisSpacePlane);
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                _healthBarInterface.Execute(StateUI.HealthBarUISimple);
            }
            else if (Input.GetKeyDown(KeyCode.F4))
            {
                _healthBarInterface.Execute(StateUI.None);
            }
            else if (_healthBarInterface.CurrentWindow != null)
            {
                _healthBarInterface.PlayerHealthBar(_healthBarInterface.CurrentWindow);
            }
        }

        #endregion
    }
}
