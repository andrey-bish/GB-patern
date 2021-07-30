using Asteroids.Interface;
using Asteroids.Dataset;


namespace Asteroids.Modification
{
    class ModificationAimLaser : ModificationWeapon
    {
        private readonly DataWeapon _dataWeapon;
        private readonly IAimLaser _aimLaser;

        public ModificationAimLaser(IAimLaser aimLaser, DataWeapon dataWeapon)
        {
            _aimLaser = aimLaser;
            _dataWeapon = dataWeapon;
        }

        protected override IWeapon AddModification(IWeapon weapon)
        {
            weapon.SetAimLaser(_aimLaser.ViewAimLaser);
            return weapon;
        }

        protected override IWeapon ResetModification(IWeapon weapon)
        {
            weapon.SetAimLaser(_dataWeapon.DefaultLaserAim);
            return weapon;
        }
    }
}
