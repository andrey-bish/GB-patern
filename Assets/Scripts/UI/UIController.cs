using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.UI
{
    class UIController : IInitialization, IUpdateble
    {
        private readonly Stack<StateUI> _stateUI = new Stack<StateUI>();

        private BottomLeftUI _bottomLeftUI;
        private TopLeftUI _topLeftUI;
        private BaseUI _currentWindow;

        public UIController(MainControllers mainControllers, GameObject mainUI)
        {
            _bottomLeftUI = mainUI.transform.Find("Canvas/BottomLeftUI").GetComponent<BottomLeftUI>();
            _topLeftUI = mainUI.transform.Find("Canvas/TopLeftUI").GetComponent<TopLeftUI>();
            mainControllers.Add(this);
        }
        private void Execute(StateUI stateUI, bool isSave = true)
        {
            Debug.Log("Execute");
            Debug.Log("Starting stateUI.Count " + _stateUI.Count);
            if (isSave)
            {
                Debug.Log("if (isSave)");
                _stateUI.Push(stateUI);
                Debug.Log("stateUI.Count " + _stateUI.Count);
            }
            
            if (_currentWindow != null)
            {
                Debug.Log("if (_currentWindow != null)");
                _currentWindow.Cancel();
            }

                switch (stateUI)
                {

                    case StateUI.TopLeftUI:
                        Debug.Log("case StateUI.TopLeftUI:");
                        _currentWindow = _topLeftUI;
                        break;
                    case StateUI.BottomLeftUI:
                        Debug.Log(" case StateUI.BottomLeftUI:");
                        _currentWindow = _bottomLeftUI;
                        break;
                    default:
                        Debug.Log("default:");
                        break;
                }

            _currentWindow.Execute();
            Debug.Log("After switch stateUI.Count " + _stateUI.Count);
        }

        public void Initialization()
        {
            _topLeftUI.Cancel();
            _bottomLeftUI.Cancel();
        }

        public void Updateble(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.F3))
            {
                Debug.Log("if input F3");
                Execute(StateUI.TopLeftUI);
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                Debug.Log("if input F2");
                Execute(StateUI.BottomLeftUI);
            }
            if (Input.GetKeyDown(KeyCode.F4))
            {
                Debug.Log("if input F4");
                if (_stateUI.Count > 0)
                {
                    Debug.Log("if(_stateUI.Count > 0)");
                    Debug.Log("stateUI.Count " + _stateUI.Count);
                    Debug.Log("StateUIPoP - " + _stateUI.Pop());
                    Execute(_stateUI.Pop(), false);

                }
                else if (_stateUI.Count == 0)
                {
                    Debug.Log("else if (_stateUI.Count == 0)");
                    _currentWindow.Cancel();
                }
            }
        }
    }
}
