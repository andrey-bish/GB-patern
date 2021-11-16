using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids.UI
{
    class HealthBarInterface : IInitialization
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
            Interpreter.Get().GetScore(mainUI.transform.Find("Canvas/Score").GetComponent<Text>());
            _dataPlayer = data.Player;
            mainControllers.Add(this);
        }

        #endregion


        #region Methods

        public void Execute(StateUI stateUI, bool isSave = true)
        {
            if (isSave)
            {
                StateUIStack.Push(stateUI);
            }

            if (CurrentWindow != null)
            {
                CurrentWindow.Cancel();
            }

            switch (stateUI)
            {

                case StateUI.TopLeftUI:
                    CurrentWindow = _topLeftUI;
                    CurrentWindow.GetPlayerData(_dataPlayer);
                    break;
                case StateUI.BottomLeftUI:
                    CurrentWindow = _bottomLeftUI;
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
            _topLeftUI.Cancel();
            _bottomLeftUI.Cancel();

            var enemies = Object.FindObjectsOfType<MonoBehaviour>().OfType<IEnemy>();
            foreach (var enemy in enemies)
            {
                enemy.Score += Interpreter.Get().Scoring;
            }
        }

    }
}
