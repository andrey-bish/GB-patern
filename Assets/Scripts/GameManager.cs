using UnityEngine;
using Asteroids.Dataset;


namespace Asteroids
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Data _data;
        //[SerializeField] private Camera camera;

        private MainControllers _mainControllers;


        #region Unity Methods

        private void Awake()
        {
            _mainControllers = new MainControllers();
            new GameAwake().AwakeGame(_data, _mainControllers);
        }
        private void Start()
        {
            //_data.Player.Camera = camera;
            new GameInitialization().StartGame(_data, _mainControllers);
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
