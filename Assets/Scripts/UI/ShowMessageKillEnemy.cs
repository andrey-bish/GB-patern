using Asteroids.Interface;


namespace Asteroids.UI
{
    class ShowMessageKillEnemy: IUpdateble
    {
        private ListenerShowMessageDeathEnemy _listenerShowMessageDeathEnemy;

        private float _timeToRemoveMessageKilledEnemy = 2.0f;
        private float _currentTime = 0.0f;

        public void GetMainController(MainControllers mainControllers, ListenerShowMessageDeathEnemy listenerShowMessageDeathEnemy)
        {
            mainControllers.Add(this);
            _listenerShowMessageDeathEnemy = listenerShowMessageDeathEnemy;
        }

        private void TimeRemoveMessage()
        {
            _listenerShowMessageDeathEnemy._isShowPlease = false;
            _listenerShowMessageDeathEnemy.RemoveNameKilledEnemy();
        }

        public void Updateble(float deltaTime)
        {
            if (_listenerShowMessageDeathEnemy._isShowPlease)
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
