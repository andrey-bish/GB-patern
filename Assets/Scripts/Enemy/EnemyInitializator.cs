using UnityEngine;
using Asteroids.Interface;

namespace Asteroids.Enemy
{
    class EnemyInitializator : IInitialization
    {
        private readonly IEnemiesFactory _enemiesFactory;

        public EnemyInitializator(IEnemiesFactory enemiesFactory)
        {
            _enemiesFactory = enemiesFactory;
            _enemiesFactory.Create();//тут нужно скинуть кого нужно создать
        }
        public void Initialization()
        {
        }
    }
}
