using UnityEngine;
using Asteroids.Interface;


namespace Asteroids.Modification
{
    internal sealed class Muffler : IMuffler
    {
        public AudioClip AudioClipMuffler { get; }
        public Transform BarrelPositionMuffler { get; }
        public GameObject MufflerInstance { get; }
        public float VolumeFireOnMuffler { get; }

        public Muffler(AudioClip audioClipMuffler, Transform barrelPositionMuffler, GameObject mufflerInstance, float volumeFireOnMuffler)
        {
            AudioClipMuffler = audioClipMuffler;
            BarrelPositionMuffler = barrelPositionMuffler.Find("Barrel");
            MufflerInstance = mufflerInstance;
            VolumeFireOnMuffler = volumeFireOnMuffler;
        }
    }
}
