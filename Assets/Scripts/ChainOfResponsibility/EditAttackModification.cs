using Asteroids.Interface;

namespace Asteroids.Modification
{
    internal sealed class EditAttackModification : WeaponModification
    {
        private readonly float _attack;

        public EditAttackModification(IWeapon weapon, float attack) : base(weapon)
        {
            _attack = attack;
        }

        public override void Handle()
        {
            _weapon.SetDamage(_attack);
            base.Handle();
        }
    }
}
