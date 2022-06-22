using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bracelets : Ship
{
    private Boss _boss;
    private Animator _anim;
    private SingleStraightShotGun _gun;
    
    

    protected override void Awake()
    {
        _boss = GetComponentInParent<Boss>();
        _anim = GetComponent<Animator>();
        _gun = GetComponent<SingleStraightShotGun>();
    }

    public override void OnDieListener()
    {
        _boss.TakeDamage(_boss.Data.Life / 4);
        _boss.IncrementRotationSpeed(20);
        _boss.ChangeRotationDirection();
        DeactivateBracelet();
        
        //base.OnDieListener();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _anim.SetTrigger("Damage");
    }

    public void DeactivateBracelet()
    {
        if(_gun)
            _gun.enabled = false;
        if(_boss.state != BossState.Dead)
            StartCoroutine(ToggleBracelet(Data.Speed));
    }

    public void ActivateBracelet()
    {
        _gun.enabled = true;
    }
    
    IEnumerator ToggleBracelet(float time)
    {
        _anim.SetBool("Active", false);

        yield return new WaitForSeconds(time);

        _anim.SetBool("Active", true);
    }
}
