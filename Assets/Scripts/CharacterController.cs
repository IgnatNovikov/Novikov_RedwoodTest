using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private UnityEngine.CharacterController _controller;
    [SerializeField] private CharacterAnimator _animator;

    [Header("Character parameters")]
    [SerializeField] private float _movementSpeed;

    private InputActions _inputActions;
    private InputAction _move;
    private InputAction _shoot;

    private Vector2 _moveDirection;

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _move = _inputActions.PlayerActions.Move;
        _move.Enable();

        _shoot = _inputActions.PlayerActions.Shot;
        _shoot.Enable();
        _shoot.performed += OnShoot;
    }

    private void OnDisable()
    {
        _move.Disable();
        _shoot.Disable();
    }

    private void Update()
    {
        _moveDirection = _move.ReadValue<Vector2>();
        _animator.Moving(_moveDirection);
    }

    private void FixedUpdate()
    {
        _controller.Move(_moveDirection * _movementSpeed);
    }

    private void OnShoot(InputAction.CallbackContext callback)
    {
        Debug.Log("Shot");
        _animator.Shot();
    }
}
