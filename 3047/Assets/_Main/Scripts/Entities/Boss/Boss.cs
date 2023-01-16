using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum BossState
{
    Phase1,
    Phase2,
    Dead,
}
public class Boss : Ship
{
    //Que tiene que tener?
    //Un script que lo mueva
    //Un script que lo haga girar
    //Diferntes estados
    //Alguna manera de aumentar la dificulta cuando le quede menos vida, se me ocurre cuando le quede menos del 50% de la segunda barra de vida sumarle a la velocidad 0.02 cada segundo.
    // Tien 6 brazaletes 2 en la primera face y 4 en la segunda, 2 barras de vida y cuando le destrullen los brazaletes se le disminulle la vida 50 porciento en la primera face y 25 en la segunda.

    public BossState state = BossState.Phase1;
    [SerializeField] private Bracelets[] _bracelets;

    private Rotation _rotation;

    //[SerializeField] private float _fireRateIncrementPercentage = 20f;

    public UnityEvent OnDestroyedBracelet = new UnityEvent();
    
    protected override void Awake()
    {
        base.Awake();
        _rotation = GetComponent<Rotation>();
        _bracelets = GetComponentsInChildren<Bracelets>();
    }

    protected override void Start()
    {
        base.Start();
        // foreach (Bracelets bracelet in _bracelets)
        // {
        //     if (bracelet)
        //         bracelet.Damageable.OnDie.AddListener(OnBraceletDieListener);
        // }
    }

    public override void Move(Vector3 dir)
    {

    }

    public void Rotate()
    {
        if(_rotation)
            _rotation.Rotate();
    }

    public void ChangeRotationDirection()
    {
        if(_rotation)
            _rotation.ChangeRotationDirection();
    }

    public void IncrementRotationSpeed(float pct)
    {
        if(_rotation)
            _rotation.IncrementRotationSpeed(pct);
    }

    public void ChangeState()
    {

    }

    public override void DieHandler()
    {
        // if (state == BossState.Phase1)
        // {
        //     _damagable.ResetValues();
        //     state = BossState.Phase2;
        // }
        // else if (state == BossState.Phase2)
        // {
        //     base.OnDieListener();
        // }
        
        state = BossState.Dead;
        GameManager.instance.GameCompleted();
        base.DieHandler();
        
    }

    // public void OnBraceletDieListener()
    // {
    //     foreach (Bracelets bracelet in _bracelets)
    //     {
    //         bracelet.ChangeFireRate(_fireRateIncrementPercentage);
    //     }
    // }
}
