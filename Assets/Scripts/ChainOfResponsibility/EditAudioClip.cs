using UnityEngine;
using Asteroids.Interface;


namespace Asteroids.Modification
{
    class EditAudioClip: WeaponModification
    {
        private AudioClip _audioClipMuffler;

        public EditAudioClip(IWeapon weapon, AudioClip audioClipMuffler) : base(weapon)
        {
            _audioClipMuffler = audioClipMuffler;
        }

        public override void Handle()
        {
            _weapon.SetAudioClip(_audioClipMuffler);
            base.Handle();
        }
    }
}
