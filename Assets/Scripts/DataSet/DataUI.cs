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
        public HealthBarUISimple TopLeftUIPrefab;
        public GameObject TopLeftUIGO;

        [Header("BottomLeftUI")]
        public HealthBarUIWhisSpacePlane BottomLeftUIPrefab;

    }
}
