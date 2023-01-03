using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    // ToDo: Refactorizar playermovemn.cs
    public Action<Vector3> OnMovementInput;
    public Action OnFireInput;
    public Action OnDodgeInput;
    public Vector2 MoveDir { get; private set; }
    public float MoveAmount { get; private set; }
    private PlayerControls _inputActions;
    private bool _canUseInputs = true;
    private bool _fireInput;

    private void OnEnable()
    {
        if (_inputActions == null)
        {
            _inputActions = new PlayerControls();
            _inputActions.Player.Movement.performed += MovementPerformedHandler;
            _inputActions.Player.Movement.canceled += MovementCanceledHandler;
            _inputActions.Player.Fire.performed += FirePerformedHandler;
            _inputActions.Player.Fire.canceled += FireCanceledHandler;
            _inputActions.Player.Dodge.performed += DodgePerformedHandler;
        }
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.Movement.performed -= MovementPerformedHandler;
        _inputActions.Player.Fire.performed -= FirePerformedHandler;
        _inputActions.Player.Fire.canceled -= FireCanceledHandler;
        _inputActions.Player.Dodge.performed -= DodgePerformedHandler;
    }
    private void Update()
    {
        HandleInput();
    }

    public void EnableInputs(bool canUseInputs) => _canUseInputs = canUseInputs;

    #region InputEvents

    private void MovementPerformedHandler(InputAction.CallbackContext context)
    {
        if (!_canUseInputs) return;
        MoveDir = context.ReadValue<Vector2>();
    }

    private void MovementCanceledHandler(InputAction.CallbackContext context)
    {
        if (!_canUseInputs) return;
        MoveDir = Vector2.zero;
    }
    
    private void DodgePerformedHandler(InputAction.CallbackContext context)
    {
        if (!_canUseInputs) return;
        OnDodgeInput?.Invoke();
    }
    
    private void FirePerformedHandler(InputAction.CallbackContext context) => _fireInput = _canUseInputs;
    private void FireCanceledHandler(InputAction.CallbackContext context) => _fireInput = false;


    #endregion
    
    
    private void HandleInput()
    {
        MoveInput();
        FireInput();
    }
    private void MoveInput()
    {
        if (MoveDir == Vector2.zero) return;
        MoveAmount = Mathf.Clamp01(Mathf.Abs(MoveDir.x) + Mathf.Abs(MoveDir.y));
        if (MoveAmount <= 0) return;
        // ToDo: refactorizar playermovement.cs
        // OnMovementInput?.Invoke(MoveDir, MoveAmount);
        OnMovementInput?.Invoke(MoveDir);
    }
    private void FireInput()
    {
        if (!_fireInput) return;
        OnFireInput?.Invoke();
    }
}
