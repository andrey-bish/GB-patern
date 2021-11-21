using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Interface;


namespace Asteroids.UI
{
    class UIInitialize : IAwakeble
    {
        private Data _data;
        private MainControllers _mainControllers;

        public UIInitialize(Data data, MainControllers mainControllers)
        {
            _data = data;
            _mainControllers = mainControllers;
        }

        public void Awakeble()
        {
            new InputUIController(_mainControllers, Object.Instantiate(_data.UI.MainUI), _data);
        }
    }
}
