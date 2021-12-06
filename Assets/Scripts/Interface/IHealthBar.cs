using Asteroids.Dataset;


namespace Asteroids.Interface
{
    interface IHealthBar
    {
        void GetPlayerData(DataPlayer dataPlayer);

        void CheckHealth();
    }
}
