using System.Collections.Generic;


namespace Asteroids
{
    public sealed class MainControllers : IInitialization, IUpdateble, IFixUpdateble, ICleanup
    {
        private readonly List<IInitialization> _initializationControllers;
        private readonly List<IUpdateble> _updatebleControllers;
        private readonly List<IFixUpdateble> _fixUpdatebleControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal MainControllers()
        {
            _initializationControllers = new List<IInitialization>();
            _updatebleControllers = new List<IUpdateble>();
            _fixUpdatebleControllers = new List<IFixUpdateble>();
            _cleanupControllers = new List<ICleanup>();
        }


        #region Add controllers

        internal MainControllers Add(IController controller)
        {
            if (controller is IInitialization initializeController)
            {
                _initializationControllers.Add(initializeController);
            }

            if (controller is IUpdateble updatebleController)
            {
                _updatebleControllers.Add(updatebleController);
            }

            if (controller is IFixUpdateble fixUpdatebleController)
            {
                _fixUpdatebleControllers.Add(fixUpdatebleController);
            }

            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }

        #endregion


        #region Implementation interface

        public void Initialization()
        {
            for (var index = 0; index < _initializationControllers.Count; ++index)
            {
                _initializationControllers[index].Initialization();
            }
        }

        public void Updateble(float deltaTime)
        {
            for (var index = 0; index < _updatebleControllers.Count; ++index)
            {
                _updatebleControllers[index].Updateble(deltaTime);
            }
        }

        public void FixUpdateble(float deltaTime)
        {
            for (var index = 0; index < _fixUpdatebleControllers.Count; ++index)
            {
                _fixUpdatebleControllers[index].FixUpdateble(deltaTime);
            }
        }

        public void Cleanup()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }

        #endregion

    }
}
