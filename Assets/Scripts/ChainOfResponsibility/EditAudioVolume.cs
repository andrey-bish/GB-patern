using Asteroids.Interface;

namespace Asteroids.Modification
{
    internal class EditAudioVolume: WeaponModification
    {
        private float _volumeWithMuffler;
        
        public EditAudioVolume(IWeapon weapon, float volumeWithMuffler):base(weapon)
        {
            _volumeWithMuffler = volumeWithMuffler;
        }

        public override void Handle()
        {
            _weapon.SetShotVolume(_volumeWithMuffler);
            base.Handle();
        }
    }
}
