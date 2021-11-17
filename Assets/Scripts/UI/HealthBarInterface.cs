using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids.UI
{
    class HealthBarInterface : IInitialization
    {
        #region Fields

        public readonly Stack<StateUI> StateUIStack = new Stack<StateUI>();

        public BaseUI CurrentWindow;

        private HealthBarUIWhisSpacePlane _healthBarUIWhisSpacePlane;
        private HealthBarUISimple _healthBarUISimple;
        private DataPlayer _dataPlayer;

        #endregion


        #region Constructor

        public HealthBarInterface(MainControllers mainControllers, GameObject mainUI, Data data)
        {
            _healthBarUIWhisSpacePlane = mainUI.transform.Find("Canvas/BottomLeftUI").GetComponent<HealthBarUIWhisSpacePlane>();
            _healthBarUISimple = mainUI.transform.Find("Canvas/TopLeftUI").GetComponent<HealthBarUISimple>();
            Interpreter.Get().GetScore(mainUI.transform.Find("Canvas/Score").GetComponent<Text>());
            _dataPlayer = data.Player;
            mainControllers.Add(this);
        }

        #endregion


        #region Methods

        public void Execute(StateUI stateUI)
        {
            if (CurrentWindow != null)
            {
                CurrentWindow.Cancel();
            }

            if(stateUI == StateUI.None)
            {
                if (StateUIStack.Count == 0)
                    return;
                StateUIStack.Pop();
                if (StateUIStack.Count == 0)
                    return;
                stateUI = StateUIStack.Pop();
            }

            StateUIStack.Push(stateUI);

            switch (stateUI)
            {
                case StateUI.HealthBarUISimple:
                    CurrentWindow = _healthBarUISimple;
                    CurrentWindow.GetPlayerData(_dataPlayer);
                    break;
                case StateUI.HealthBarUIWhisSpacePlane:
                    CurrentWindow = _healthBarUIWhisSpacePlane;
                    CurrentWindow.GetPlayerData(_dataPlayer);
                    break;
                default:
                    break;
            }

            CurrentWindow.Execute();
        }

        public void PlayerHealthBar(IHealthBar healthBar)
        {
            healthBar.CheckHealth();
        }

        #endregion


        public void Initialization()
        {
            _healthBarUISimple.Cancel();
            _healthBarUIWhisSpacePlane.Cancel();
        }
    }
}
