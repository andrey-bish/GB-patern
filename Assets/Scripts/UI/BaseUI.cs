using UnityEngine;

namespace Asteroids.UI
{
    public abstract class BaseUI : MonoBehaviour
    {
        public abstract void Execute();
        public abstract void Cancel();
    }
}

