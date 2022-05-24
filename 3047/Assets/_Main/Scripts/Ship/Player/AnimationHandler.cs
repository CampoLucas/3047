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

    public void UpdateAnimValues(float horizontal, float vertical, bool isBoosting)
    {
        //float h = 0;

        //if (horizontal > 0 && horizontal < .55f)
        //    h = .5f;
        //else if (horizontal > .55f)
        //    h = 1;
        //else if (horizontal < 0 && horizontal > -.55f)
        //    h = -.5f;
        //else if (horizontal < -.55f)
        //    h = -1;
        //else
        //    h = 0;

        //float v = 0;

        //if (vertical > 0 && vertical < .55f)
        //    v = .5f;
        //else if (vertical > .55f)
        //    v = 1;
        //else if (vertical < 0 && vertical > -.55f)
        //    v = -.5f;
        //else if (vertical < -.55f)
        //    v = -1;
        //else 
        //    v = 0;

        //if (isBoosting)
        //{
        //    if(horizontal > .55f)
        //    h = 2;
        //}

        float h = horizontal;
        float v = vertical;

        if (horizontal > .55f && isBoosting)
            h = 2;
        else if (horizontal < -.55f && isBoosting)
            h = -2;

        anim.SetFloat(this.vertical, v, 0.1f, Time.deltaTime);
        anim.SetFloat(this.horizontal, h, 0.1f, Time.deltaTime);
    }
}
