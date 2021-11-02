using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.UI
{
    public class BottomLeftUI : BaseUI
    {
        [SerializeField] private Text _text;

        public override void Execute()
        {
            _text.text = nameof(BottomLeftUI);
            gameObject.SetActive(true);
        }
        public override void Cancel()
        {
            Debug.Log("Cancel " +nameof(BottomLeftUI));
            gameObject.SetActive(false);
        }
    }
}
