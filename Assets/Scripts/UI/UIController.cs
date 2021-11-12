using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.UI
{
    class UIController : IUpdateble
    {
        #region Fields

        private HealthBarInterface _healthBarInterface;
        public readonly Stack<StateUI> _stateUIStack = new Stack<StateUI>();

        #endregion


        #region Constructor

        public UIController(MainControllers mainControllers, GameObject mainUI, Data data)
        {
            _healthBarInterface = new HealthBarInterface(mainControllers, mainUI, data);
            _stateUIStack = _healthBarInterface.StateUIStack;
            mainControllers.Add(this);
        }

        #endregion


        #region UnityMethods

        public void Updateble(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.F3))
            {
                Debug.Log("if input F3");
                _healthBarInterface.Execute(StateUI.TopLeftUI);
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                Debug.Log("if input F2");
                _healthBarInterface.Execute(StateUI.BottomLeftUI);
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                Debug.Log("if input F4");
                if (_stateUIStack.Count > 0)
                {
                    Debug.Log("if(_stateUI.Count > 0)");
                    Debug.Log("stateUI.Count " + _stateUIStack.Count);
                    Debug.Log("StateUIPoP - " + _stateUIStack.Pop());
                    _healthBarInterface.Execute(_stateUIStack.Pop(), false);

                }
                else if (_stateUIStack.Count == 0)
                {
                    Debug.Log("else if (_stateUI.Count == 0)");
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
