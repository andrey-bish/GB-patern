using UnityEngine;
using UnityEngine.UI;
using Asteroids.Interface;


namespace Asteroids.UI
{
    class ImplementationMediator: IInitialization
    {
        private Text _text;

        public ImplementationMediator(GameObject mainUI, MainControllers mainControllers)
        {
            _text = mainUI.transform.Find("Canvas/KillEnemy").GetComponent<Text>();
            new ShowMessageKillEnemy().GetMainController(mainControllers);
        }

        public void Initialization()
        {
            ConcreteMediator.Get().GetText(_text);
        }
    }
}
