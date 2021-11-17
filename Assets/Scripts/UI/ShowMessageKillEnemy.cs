using Asteroids.Interface;
using Asteroids.Models;
using UnityEngine;

namespace Asteroids.UI
{
    class ShowMessageKillEnemy: IUpdateble
    {
        private ConcreteMediator _concreteMediator;

        private float _timeToRemoveMessageKilledEnemy = 2.0f;
        private float _currentTime = 0.0f;

        public void GetMainController(MainControllers mainControllers)
        {
            mainControllers.Add(this);
            _concreteMediator = ConcreteMediator.Get();
        }

        private void TimeRemoveMessage()
        {
            _concreteMediator._isShowPlease = false;
            _concreteMediator.RemoveNameKilledEnemy();
        }

        public void Updateble(float deltaTime)
        {
            if (_concreteMediator._isShowPlease)
            {
                _currentTime += deltaTime;
                if (_currentTime > _timeToRemoveMessageKilledEnemy)
                {
                    TimeRemoveMessage();
                    _currentTime = 0.0f;
                }
            }
        }
    }
}
