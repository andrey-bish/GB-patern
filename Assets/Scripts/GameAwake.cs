using System.Collections.Generic;
using Asteroids.Dataset;
using Asteroids.Enemy;
using Asteroids.UI;
using Asteroids.Interface;


namespace Asteroids
{
    class GameAwake
    {
        public void AwakeGame(Data data, MainControllers mainControllers)
        {
            List<IAwakeble> AwakeObjectList = new List<IAwakeble>();

            AwakeObjectList.Add(UIInitialization(data, mainControllers));

            AddInMainController(AwakeObjectList, mainControllers);

            mainControllers.Awakeble();
        }

        private UIInitialize UIInitialization(Data data, MainControllers mainControllers)
        {
            return new UIInitialize(data, mainControllers);
        }

        private void AddInMainController(List<IAwakeble> AwakeObjectList, MainControllers mainControllers)
        {
            foreach (IAwakeble AwakeObject in AwakeObjectList)
            {
                mainControllers.Add(AwakeObject);
            }
        }
    }
}
