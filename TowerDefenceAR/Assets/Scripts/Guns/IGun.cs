namespace Assets.Scripts.Guns
{
    public interface IGun
    {
        bool IsReady { get; }
        void Shoot();
    }
}
