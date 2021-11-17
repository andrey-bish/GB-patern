using UnityEngine;
using Asteroids.Dataset;


namespace Asteroids
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Data _data;

        private MainControllers _mainControllers;


        #region Unity Methods

        private void Start()
        {
            _mainControllers = new MainControllers();
            var InitializationGame = new GameInitialization();
            InitializationGame.StartGame(_data, _mainControllers);
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

        private void OnDisable()
        {
            _mainControllers.Cleanup();
        }


        #endregion
    }
}
