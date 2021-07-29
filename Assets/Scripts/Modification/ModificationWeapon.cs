using Asteroids.Interface;


namespace Asteroids.Modification
{
    abstract class ModificationWeapon : IShooting
    {
        private IWeapon _weapon;

        protected abstract IWeapon AddModification(IWeapon weapon);
        protected abstract IWeapon ResetModification(IWeapon weapon);

        public void ApplyModification(IWeapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void CancelModification(IWeapon weapon)
        {
            _weapon = ResetModification(weapon);
        }

        public void Shooting()
        {
            _weapon.Shooting();
        }
    }
}
