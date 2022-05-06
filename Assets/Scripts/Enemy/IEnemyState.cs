namespace Avega.Enemy
{
    public interface IEnemyState
    {
        void Init(Player player);
        void LocalUpdate();
    }
}