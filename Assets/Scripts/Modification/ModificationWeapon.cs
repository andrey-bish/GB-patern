using Asteroids.Interface;


namespace Asteroids.Modification
{
    abstract class ModificationWeapon : IShooting
    {
        private Weapon _weapon;

        protected abstract Weapon AddModification(Weapon weapon);
        protected abstract Weapon ResetModification(Weapon weapon);

        public void ApplyModification(Weapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void CancelModification(Weapon weapon)
        {
            _weapon = ResetModification(weapon);
        }

        public void Shooting()
        {
            _weapon.Shooting();
        }
    }
}
