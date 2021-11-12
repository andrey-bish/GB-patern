using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Interface;

namespace Asteroids.UI
{
    public abstract class BaseUI : MonoBehaviour, IHealthBar
    {
        public abstract void Execute();
        public abstract void Cancel();

        public abstract void GetPlayerData(DataPlayer dataPlayer);

        public abstract void CheckHealth();
    }
}

