using UnityEngine;
using UnityEngine.UI;
using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids
{
    class ListenerShowMessageDeathEnemy
    {
        public bool _isShowPlease = false;

        private Text _messageDeathText;
        private Text _scoreText;

        public ListenerShowMessageDeathEnemy(Data data)
        {
            _scoreText = data.UI.LinkToMainUI.transform.Find("Canvas/Score").GetComponent<Text>();
            _messageDeathText = data.UI.LinkToMainUI.transform.Find("Canvas/KillEnemy").GetComponent<Text>();
        }

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
            _scoreText.text = "Score: " + Interpreter.Get().Scoring(enemy.KillPoint);

            _messageDeathText.text = (enemy as MonoBehaviour).gameObject.name.Replace("(Clone)", "") + " погиб!";
            _messageDeathText.gameObject.SetActive(true);
            _isShowPlease = true;

            Remove(enemy);
        }

        public void RemoveNameKilledEnemy()
        {
            _messageDeathText.gameObject.SetActive(false);
        }
    }
}
