using System.Collections;
using System.Collections.Generic;

public interface IDamagable
{
    void TakeDamage(int damage);
    void AddLife(int healing);
    void DieHandler();
    
}
