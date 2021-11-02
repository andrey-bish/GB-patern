using UnityEngine;
using UnityEngine.UI;
using Asteroids.UI;

namespace Asteroids.Dataset
{
    [CreateAssetMenu(fileName = "UI", menuName = "Data/UISettings")]
    public class DataUI : ScriptableObject
    {
        public GameObject MainUI;

        [Header("TopLeftUI")]
        public TopLeftUI TopLeftUIPrefab;
        public Text TextTopLeftUI;
        public Image ImageTopLeftUI;

        [Header("BottomLeftUI")]
        public BottomLeftUI BottomLeftUIPrefab;
        public Text TextBottomLeftUI;

    }
}
