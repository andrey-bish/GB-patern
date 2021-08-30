using System;

namespace Json
{
    class CompositFactory
    {
        public IEnemy Create(float health, string typeName)
        {
            IEnemy enemy;

            switch (typeName.ToLower())
            {
                case "mag":
                    enemy = new MagFactory().Create(health);
                    break;

                case "infantry":
                    enemy = new InfantryFactory().Create(health);
                    break;
                default:
                    throw new NullReferenceException("There is no such type in the composition of factories.");
            }

            return enemy;
        }
    }
}
