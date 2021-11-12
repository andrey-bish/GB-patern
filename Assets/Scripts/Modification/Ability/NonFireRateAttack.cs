using UnityEngine;
using System.Collections;
using Asteroids.Interface;


namespace Asteroids.Modification.Ability
{
    internal class NonFireRateAttack : IAbility
    {
        private IWeapon _fire;
        private int _fireCount;

        public AbilityType Type { get; }
        public AttackAbilityType AttackType { get; }
        public string Name { get; }
        public int Points { get; }

        public NonFireRateAttack(IWeapon weapon, AbilityType type,
            AttackAbilityType attackType, string name, int points, int fireCount)
        {
            _fire = weapon;
            Type = type;
            AttackType = attackType;
            Name = name;
            Points = points;
            _fireCount = fireCount;
        }

        public void Execute()
        {
            _fire.SetFireFireCooldown(-5.0f);
            var enumerator = Firing(_fireCount);
            _fire.SetFireFireCooldown(5.0f);
        }

        private IEnumerator Firing(int count)
        {
            for (int i = 0; i < count; i++)
            {
                _fire.Shooting();
                yield return new WaitForSeconds(0.5f);
            }
            yield break;
        }
    }
}