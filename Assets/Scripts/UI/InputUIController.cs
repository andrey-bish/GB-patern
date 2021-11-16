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
            _healthBarInterface = new HealthBarInterface(mainControllers, mainUI, data);
            _stateUIStack = _healthBarInterface.StateUIStack;
            mainControllers.Add(this);
            mainControllers.Add(new ImplementationMediator(mainUI, mainControllers));
        }

        #endregion


        #region UnityMethods

        public void Updateble(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.F3))
            {
                _healthBarInterface.Execute(StateUI.TopLeftUI);
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                _healthBarInterface.Execute(StateUI.BottomLeftUI);
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                if (_stateUIStack.Count > 0)
                {
                    _healthBarInterface.Execute(_stateUIStack.Pop(), false);

                }
                else if (_stateUIStack.Count == 0)
                {
                    _healthBarInterface.CurrentWindow.Cancel();
                }
            }
            if (_healthBarInterface.CurrentWindow != null)
            {
                _healthBarInterface.PlayerHealthBar(_healthBarInterface.CurrentWindow);
            }
        }

        #endregion
    }
}
