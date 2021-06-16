﻿using UnityEngine;
using Asteroids.Dataset;
using Asteroids.Enemy;


namespace Asteroids
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Data _data;

        private MainControllers _mainControllers;


        #region Unity Methods

        private void Start()
        {
            var initialize = new PlayerInitialize(_data);
            var enemyFactory = new EnemiesFactory(_data.Enemies);
            var enemyInitializator = new EnemyInitializator(enemyFactory);
            var bulletInitializator = new Bullet(_data.Enemies);
            _mainControllers = new MainControllers();
            _mainControllers.Add(initialize);
            _mainControllers.Add(enemyInitializator);
            _mainControllers.Add(bulletInitializator);
            _mainControllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _mainControllers.Updateble(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.deltaTime;
            _mainControllers.FixUpdateble(deltaTime);
        }

        private void OnDestroy()
        {
            _mainControllers.Cleanup();
        }

        #endregion
    }
}
