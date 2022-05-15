using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Components")]
    private PlayerControls _inputActions;
    private Ship _player;

    [Header("Movement")]
    public float horizontal;
    public float vertical;

    bool shoot_Input;
    bool boost_Input;
    bool dodge_Input;

    private Vector2 _movementInput;

    private void Awake()
    {
        _player = GetComponent<Ship>();
    }
    private void Update()
    {
        //HandleInput();

        _player.Move(new Vector3(horizontal, vertical));
        _player.Boost(boost_Input);
        if (shoot_Input)
            _player.Fire();
        if (dodge_Input)
            _player.Dodge();
    }
    private void LateUpdate()
    {
        dodge_Input = false;
    }

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.PlayerMovements.Movement.performed += inputActions => _movementInput = inputActions.ReadValue<Vector2>();
        }
        _inputActions.Enable();
    }
    private void OnDisable() => _inputActions.Disable();

    private void HandleInput()
    {
        MoveInput();
        ShootInput();
        BoostInput();
        DodgeInput();
    }
    private void MoveInput()
    {
        horizontal = _movementInput.x;
        vertical = _movementInput.y;
    }
    private void ShootInput()
    {
        _inputActions.PlayerActions.Shoot.started += i => shoot_Input = true;
        _inputActions.PlayerActions.Shoot.canceled += i => shoot_Input = false;
    }
    private void BoostInput()
    {
        _inputActions.PlayerActions.Boost.started += i => boost_Input = true;
        _inputActions.PlayerActions.Boost.canceled += i => boost_Input = false;
    }
    private void DodgeInput()
    {
        _inputActions.PlayerActions.Dodge.started += i => boost_Input = true;
    }
}
