using UnityEngine;
using UnityEngine.UI;
using Asteroids.Interface;


namespace Asteroids
{
    class ListenerShowMessageDeathEnemy
    {
        public bool _isShowPlease = false;

        private Text _text;

        public void Add(IEnemy value)
        {
            value.TestEnemyDead += ShowMessageDeathEnemy;
        }

        public void Remove(IEnemy value)
        {
            value.TestEnemyDead -= ShowMessageDeathEnemy;
        }

        private void ShowMessageDeathEnemy(IEnemy enemy)
        {
            _text.text = (enemy as MonoBehaviour).gameObject.name.Replace("(Clone)", "") + " погиб!";
            _text.gameObject.SetActive(true);
            _isShowPlease = true;
        }
        public void RemoveNameKilledEnemy()
        {
            _text.gameObject.SetActive(false);
        }
    }
}
