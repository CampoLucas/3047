using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimation
{
    void UpdateAnimValues(float horizontal, float vertical, bool isBoosting);
}
