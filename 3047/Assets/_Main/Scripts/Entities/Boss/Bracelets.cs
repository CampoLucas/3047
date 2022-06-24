using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bracelets : Ship
{
    private Boss _boss;
    private Animator _anim;
    private SingleStraightShotGun _gun;

    [SerializeField] private GameObject _explosion;

    protected override void Awake()
    {
        _boss = GetComponentInParent<Boss>();
        _anim = GetComponent<Animator>();
        _gun = GetComponent<SingleStraightShotGun>();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void OnDieListener()
    {
        _boss.TakeDamage(_boss.Data.Life / 4);
        _boss.IncrementRotationSpeed(20);
        _boss.ChangeRotationDirection();
        Instantiate(_explosion, transform.position, Quaternion.identity);
        base.OnDieListener();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _anim.SetTrigger("Damage");
    }

    
}
