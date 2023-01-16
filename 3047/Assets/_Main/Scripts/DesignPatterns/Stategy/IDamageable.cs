/// <summary>
/// The set of rules every damageable entity should have
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// Event for when the life changes
    /// </summary>
    event LivesUpdatedDelegate OnLivesUpdated;
    /// <summary>
    /// Event for when the entity has died
    /// </summary>
    event DieDelegate OnDie;
    /// <summary>
    /// Subtracts an amount of life
    /// </summary>
    /// <param name="amount"></param>
    void TakeDamage(int amount);
    /// <summary>
    /// Adds more life
    /// </summary>
    /// <param name="healing"></param>
    void AddLife(int healing);
    /// <summary>
    /// Bool to know if it is alive
    /// </summary>
    /// <returns></returns>
    bool IsAlive();
    /// <summary>
    /// Resets all the stats
    /// </summary>
    void Reset();
}

public delegate void LivesUpdatedDelegate(float lives, float maxLives);
public delegate void DieDelegate();