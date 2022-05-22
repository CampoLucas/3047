using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private IAnimation _anim;
    protected override void Awake()
    {
        base.Awake();
        _anim = GetComponent<IAnimation>();
    }

    public void Boost(bool boost)
    {
       
    }
    public void Dodge()
    {
       
    }
    public void UpdateAnimation(Vector2 direction)
    {
        if (_anim != null)
            _anim.UpdateAnimValues(direction.x, direction.y);
    }
}
