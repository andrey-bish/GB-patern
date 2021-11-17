using UnityEngine;
using UnityEngine.UI;
using Asteroids.Interface;


namespace Asteroids.Models
{
    class ConcreteMediator : IMediator
    {
        public bool _isShowPlease = false;

        private Text _text;


        private static ConcreteMediator obj;
        public static ConcreteMediator Get()
        {
            if (obj == null)
                obj = new ConcreteMediator();
            return obj;
        }

        public void Notify(IEnemy enemy)
        {
            ShowNameKilledEnemy(enemy);
        }

        public void GetText(Text text)
        {
            _text = text;
        }

        private void ShowNameKilledEnemy(IEnemy enemy)
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
