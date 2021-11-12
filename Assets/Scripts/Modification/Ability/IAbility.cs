using Asteroids.Modification.Ability;


namespace Asteroids.Interface
{
    interface IAbility
    {
        AbilityType Type { get; }
        AttackAbilityType AttackType { get; }
        string Name { get; }
        int Points { get; }

        void Execute();
    }
}