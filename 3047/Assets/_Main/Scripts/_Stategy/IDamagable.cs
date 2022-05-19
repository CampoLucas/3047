using System.Collections;
using System.Collections.Generic;

public interface IDamagable
{
    void GetDamage(int damage);
    void GetHealing(int healing);
    void DieHandler();
}
