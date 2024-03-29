﻿using System.Collections.Generic;
using Asteroids.Dataset;
using Asteroids.Enemy;
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

            AddInMainController(InitializeObjectList, mainControllers);

            mainControllers.Initialization();
        }

        private PlayerInitialize PlayerInitialization(Data data, MainControllers mainControllers)
        {
            return new PlayerInitialize(data, mainControllers);
        }
        
        private EnemyInitializator EnemyInitialization(Data data, MainControllers mainControllers)
        {
            return new EnemyInitializator(mainControllers, data);
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
