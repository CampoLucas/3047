using System.Collections;
using System.Collections.Generic;

public interface IDamageable
{
    int CurrentLife { get; }
    bool IsInvulnerable { get; }
    void TakeDamage(int damage);
    void AddLife(int healing);
    void Die();
    
}
