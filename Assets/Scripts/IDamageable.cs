public interface IDamageable
{
    int Health { get; }

    public void ReduceHealth(int point);
}
