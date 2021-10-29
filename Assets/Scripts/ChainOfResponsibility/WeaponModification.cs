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

        public void Add(WeaponModification cm)
        {
            if(Next != null)
            {
                Next.Add(cm);
            }
            else
            {
                Next = cm;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}
