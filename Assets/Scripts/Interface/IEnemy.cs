using System;


namespace Asteroids.Interface
{
    /// <summary>
    /// Представляет интерфейс для врагов
    /// </summary>
    public interface IEnemy
    {
        event Action<string> Score;
        event Action<IEnemy> EnemyDead;
    }
}