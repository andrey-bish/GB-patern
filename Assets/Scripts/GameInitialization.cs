using System.Collections.Generic;
using Asteroids.Dataset;
using Asteroids.Enemy;
using Asteroids.Fabrics;
using Asteroids.UI;
using Asteroids.Interface;


namespace Asteroids
{
    class GameInitialization
    {
        public void StartGame(Data data, MainControllers mainControllers)
        {
            List<IInitialization> InitializeObjectList = new List<IInitialization>();

            InitializeObjectList.Add(PlayerInitialization(data, mainControllers));
            InitializeObjectList.Add(EnemyInitialization(data, mainControllers));
            InitializeObjectList.Add(BulletInitialization(data));
            InitializeObjectList.Add(UIInitialization(data, mainControllers));

            AddInMainController(InitializeObjectList, mainControllers);

            mainControllers.Initialization();
        }

        private PlayerInitialize PlayerInitialization(Data data, MainControllers mainControllers)
        {
            return new PlayerInitialize(data, mainControllers);
        }
        
        private EnemyInitializator EnemyInitialization(Data data, MainControllers mainControllers)
        {
            return new EnemyInitializator(new AsteroidFactory(data), mainControllers, data);
        }

        private Bullet BulletInitialization(Data data)
        {
            return new Bullet(data.Enemies);
        }

        private UIInitialize UIInitialization(Data data, MainControllers mainControllers)
        {
            return new UIInitialize(data, mainControllers);
        }

        private void AddInMainController(List<IInitialization> InitializeObjectList, MainControllers mainControllers)
        {
            foreach(IInitialization InitializeObject in InitializeObjectList)
            {
                mainControllers.Add(InitializeObject);
            }
        }
    }
}
