using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.UI
{
    public class TopLeftUI : BaseUI
    {
        [SerializeField] private Text _text;
        private Image _image;

        public override void Execute()
        {
            _text.text = nameof(TopLeftUI);
            Debug.Log("Execute " + nameof(TopLeftUI));
            Debug.Log(gameObject.name); 
            gameObject.SetActive(true);
        }
        public override void Cancel()
        {
            Debug.Log("Cancel " + nameof(TopLeftUI));
            gameObject.SetActive(false);
        }
    }
}
