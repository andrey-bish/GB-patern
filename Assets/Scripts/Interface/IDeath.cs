using System;

namespace Asteroids.Interface
{
    public interface IDeath
    {
        event Action OnDeathChange;
    }
}