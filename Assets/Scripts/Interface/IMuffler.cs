using UnityEngine;

namespace Asteroids.Interface
{
    internal interface IMuffler
    {
        AudioClip AudioClipMuffler { get; }
        Transform BarrelPositionMuffler { get; }
        GameObject MufflerInstance { get; }
        float VolumeFireOnMuffler { get; }
    }
}
