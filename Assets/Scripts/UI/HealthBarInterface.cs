using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.UI
{
    class HealthBarInterface : IInitialization, IUpdateble
    {
        #region Fields

        public readonly Stack<StateUI> StateUIStack = new Stack<StateUI>();

        public BaseUI CurrentWindow;

        private BottomLeftUI _bottomLeftUI;
        private TopLeftUI _topLeftUI;
        private DataPlayer _dataPlayer;
        private Text _score;

        #endregion


        #region Constructor

        public HealthBarInterface(MainControllers mainControllers, GameObject mainUI, Data data)
        {
            _bottomLeftUI = mainUI.transform.Find("Canvas/BottomLeftUI").GetComponent<BottomLeftUI>();
            _topLeftUI = mainUI.transform.Find("Canvas/TopLeftUI").GetComponent<TopLeftUI>();
            _score = mainUI.transform.Find("Canvas/Score").GetComponent<Text>();
            _dataPlayer = data.Player;
            mainControllers.Add(this);
        }

        #endregion


        #region Methods

        public void Execute(StateUI stateUI, bool isSave = true)
        {
            Debug.Log("Execute");
            Debug.Log("Starting stateUI.Count " + StateUIStack.Count);
            if (isSave)
            {
                Debug.Log("if (isSave)");
                StateUIStack.Push(stateUI);
                Debug.Log("stateUI.Count " + StateUIStack.Count);
            }

            if (CurrentWindow != null)
            {
                Debug.Log("if (_currentWindow != null)");
                CurrentWindow.Cancel();
            }

            switch (stateUI)
            {

                case StateUI.TopLeftUI:
                    Debug.Log("case StateUI.TopLeftUI:");
                    CurrentWindow = _topLeftUI;
                    CurrentWindow.GetPlayerData(_dataPlayer);
                    break;
                case StateUI.BottomLeftUI:
                    Debug.Log(" case StateUI.BottomLeftUI:");
                    CurrentWindow = _bottomLeftUI;
                    CurrentWindow.GetPlayerData(_dataPlayer);
                    break;
                default:
                    Debug.Log("default:");
                    break;
            }

            CurrentWindow.Execute();
            Debug.Log("After switch stateUI.Count " + StateUIStack.Count);
        }

        public void PlayerHealthBar(IHealthBar healthBar)
        {
            healthBar.CheckHealth();
        }

        #endregion


        public void Initialization()
        {
            _topLeftUI.Cancel();
            _bottomLeftUI.Cancel();

            var enemies = Object.FindObjectsOfType<MonoBehaviour>().OfType<IEnemy>();
            var interpreter = new Interpreter(_score);
            foreach (var enemy in enemies)
            {
                enemy.Score += interpreter.Scoring;
            }
        }

        public void Updateble(float deltaTime)
        {
            
        }
    }
}
