using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Components")]
    private PlayerControls _inputActions;
    private Player _player;

    [Header("Movement")]
    private float _moveAmount;
    public float horizontal;
    public float vertical;

    bool Fire_Input;
    bool boost_Input;
    bool dodge_Input;

    private Vector2 _movementInput;

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.PlayerMovements.Movement.performed += inputActions => _movementInput = inputActions.ReadValue<Vector2>();

            _inputActions.PlayerActions.Boost.started += i => boost_Input = true;
            _inputActions.PlayerActions.Boost.canceled += i => boost_Input = false;

        }
        _inputActions.Enable();
    }
    private void OnDisable() => _inputActions.Disable();
    private void Awake()
    {
        _player = GetComponent<Player>();
    }
    private void Update()
    {
        HandleInput();
        Vector3 dir = new Vector3(horizontal, vertical);
        _player.Move(dir);
        _player.SetMoveAmount(_moveAmount);


        //_player.UpdateAnimation(dir, boost_Input);
        _player.UpdateAnimation(new Vector3(horizontal * _moveAmount, vertical * _moveAmount), boost_Input);




        if (Fire_Input)
            _player.Fire();

        if (dodge_Input)
            _player.Dodge();
    }
    private void LateUpdate()
    {
        dodge_Input = false;
    }


    private void HandleInput()
    {
        MoveInput();
        FireInput();
        BoostInput();
        //DodgeInput();
    }
    private void MoveInput()
    {
        horizontal = _movementInput.x;
        vertical = _movementInput.y;

        _moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }
    private void FireInput()
    {
        _inputActions.PlayerActions.Fire.started += i => Fire_Input = true;
        _inputActions.PlayerActions.Fire.canceled += i => Fire_Input = false;
    }
    private void BoostInput()
    {
        if (boost_Input && _moveAmount > 0.5)
        {
            _player.Boost(true);
        }
        else
        {
            _player.Boost(false);
        }
    }
    private void DodgeInput()
    {
        _inputActions.PlayerActions.Dodge.started += i => boost_Input = true;
    }
}
