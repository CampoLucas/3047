using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Entity //, IProduct<StatsSO> Por que IProduct? asta donde lei todavia no usas Factory, no me da ningun error al quitarlo tampoco
{
    
    [SerializeField] protected float _timeToRecycle = 2f;
    protected float _recycleTime;
    
    // public StatsSO BullletData => _bulletStats;
    // [SerializeField] protected StatsSO _bulletStats;
    public Vector3 MoveDirection => _moveDirection;
    [SerializeField] protected Vector3 _moveDirection;
    public Pool _Pool;
    
    protected ICommand _movementCommand;

    protected virtual void Start()
    {
        //InitCmd();
        _recycleTime = 0f;
    }

    protected virtual void Update()
    {
        //_movementCommand.Do(); //tiene mas sentido y es mas legible hacer el do aca que en otra clase
        //No estoy de acuerdo, para mi tiene mas sentido que esten separados, ya que de esa manera usas la interfaz de entity como acordamos y si hay un problema con el movimiento, se sabe que el problema esta ahi.
        Move(_moveDirection);
        if (_recycleTime > _timeToRecycle)
        {
            _recycleTime = 0f;
            _Pool.Recycle(gameObject);
        }

        _recycleTime += Time.deltaTime;
    }

    public virtual void InitData(Vector3 direction,Vector3 initialPosition, Pool pool)
    {
        _moveDirection = direction;
        _moveDirection.z = 0f;
        transform.position = initialPosition;
        _Pool = pool;
        _movementCommand = new CmdMove(transform, _moveDirection, _stats.Speed);
    }     
    public virtual void InitData(Vector3 direction,Vector3 initialPosition, Pool pool, float TimeToRecycle)
    {
        _timeToRecycle = TimeToRecycle;
        _moveDirection = direction;
        _moveDirection.z = 0f;
        transform.position = initialPosition;
        _Pool = pool;
        _movementCommand = new CmdMove(transform, _moveDirection, _stats.Speed);
    }

    public override void Move(Vector3 dir)
    {
        _movementCommand = new CmdMove(transform, dir, _stats.Speed);
        _movementCommand.Do();
    }
    protected virtual void InitCmd()
    {
        _movementCommand = new CmdMove(transform, _moveDirection, _stats.Speed);
    }
    //TODO Change this to collisionDamage
    protected void OnTriggerEnter(Collider other)
    {
        Ship ship = other.GetComponent<Ship>();
        if (!other.gameObject.CompareTag(this.tag) && ship)
        {
            ship.TakeDamage(_stats.Damage);
            _Pool.Recycle(gameObject);
            
        }
        
    }
    
}
