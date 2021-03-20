using System;

namespace Asteroids
{
    public interface IEnemy
    {
        event Action<int> OnTriggerEnterChange; 
    }
}