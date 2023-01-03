using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapon
{
    TripleGun,
    HelixGun,
    SingleStraightShotGun,
    SingleTargetedGun
}
public interface IGun
{
    void Fire();
    Weapon type { get; }
}
