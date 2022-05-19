using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour, IAnimation
{
    public Animator anim;
    int vertical;
    int horizontal;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Horizontal");
    }

    public void UpdateAnimValues(float verticalMov, float horizontalMov)
    {
        float v = 0;

        if (verticalMov > 0 && verticalMov < .55f)
            v = .5f;
        else if (verticalMov > .55f)
            v = 1;
        else if (verticalMov < 0 && verticalMov > -.55f)
            v = -.5f;
        else if (verticalMov < -.55f)
            v = -1;
        else 
            v = 0;

        float h = 0;

        if (horizontalMov > 0 && horizontalMov < .55f)
            h = .5f;
        else if (horizontalMov > .55f)
            h = 1;
        else if (horizontalMov < 0 && horizontalMov > -.55f)
            h = -.5f;
        else if (horizontalMov < -.55f)
            h = -1;
        else
            h = 0;

        anim.SetFloat(vertical, v, 0.1f, Time.deltaTime);
        anim.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
    }
}
