using Asteroids.Interface;

namespace Asteroids.Modification
{
    class WeaponModification
    {
        protected IWeapon _weapon;
        protected WeaponModification Next;

        public WeaponModification(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public void Add(WeaponModification weaponModification)
        {
            if(Next != null)
            {
                Next.Add(weaponModification);
            }
            else
            {
                Next = weaponModification;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}
