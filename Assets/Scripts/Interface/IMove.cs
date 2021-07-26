namespace Asteroids.Interface
{
    public interface IMove
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
        void Move();
    }
}
