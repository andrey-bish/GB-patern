using UnityEngine;


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
            _mainControllers = new MainControllers();
            _mainControllers.Add(initialize);
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
