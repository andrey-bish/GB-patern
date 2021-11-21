﻿using System;
using Asteroids.Enemy;

namespace Asteroids.Interface
{
    /// <summary>
    /// Представляет интерфейс для врагов
    /// </summary>
    public interface IEnemy
    {
        event Action<IEnemy> TestEnemyDead;
        event Action<string> Score;
        event Action<IEnemy> EnemyDead;

        string KillPoint { get; set; }

        void SetHealth(Health health);
        void Recreate();
    }
}