using Asteroids.Dataset;
using Asteroids.Enemy;
using Asteroids.Fabrics;
using System.Collections.Generic;


namespace Asteroids
{
    class GameInitialization
    {
        public void StartGame(Data data, MainControllers mainControllers)
        {
            List<IInitialization> InitializeObjectList = new List<IInitialization>();
            InitializeObjectList.Add(PlayerInitialization(data));
            InitializeObjectList.Add(EnemyInitialization(data, mainControllers));
            InitializeObjectList.Add(BulletInitialization(data));

            AddingInMainController(InitializeObjectList, mainControllers);

            mainControllers.Initialization();
        }

        private PlayerInitialize PlayerInitialization(Data data)
        {
            return new PlayerInitialize(data);
        }
        
        private EnemyInitializator EnemyInitialization(Data data, MainControllers mainControllers)
        {
            return new EnemyInitializator(new AsteroidFactory(data), mainControllers, data);
        }

        private Bullet BulletInitialization(Data data)
        {
            return new Bullet(data.Enemies);
        }

        private void AddingInMainController(List<IInitialization> InitializeObjectList, MainControllers mainControllers)
        {
            foreach(IInitialization InitializeObject in InitializeObjectList)
            {
                mainControllers.Add(InitializeObject);
            }
        }
    }
}
