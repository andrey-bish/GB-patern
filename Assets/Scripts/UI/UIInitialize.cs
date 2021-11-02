using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Interface;

namespace Asteroids.UI
{
    class UIInitialize : IInitialization
    {
        private Data _data;
        private MainControllers _mainControllers;

        public UIInitialize(Data data, MainControllers mainControllers)
        {
            _data = data;
            _mainControllers = mainControllers;
        }
        public void Initialization()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            new UIController(_mainControllers, Object.Instantiate(_data.UI.MainUI));
        }
    }
}
