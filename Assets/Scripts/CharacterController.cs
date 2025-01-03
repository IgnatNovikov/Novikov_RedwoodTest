using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CharacterController : MonoBehaviour, ICharacterPosition
{
    [SerializeField] private UnityEngine.CharacterController _controller;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Transform _cameraPositionTransform;
    [SerializeField] private int _bulletsAmount;

    [Header("Character parameters")]
    [SerializeField, Min(0)] private float _movementSpeed;

    [Header("Bullets")]
    [SerializeField] private BulletSpawner _firePoint;

    private InputActions _inputActions;
    private InputAction _move;
    private InputAction _shoot;

    private Vector2 _moveDirection;

    [Inject] private BulletsCounter _bulletsCounter;

    private void Awake()
    {
        _inputActions = new InputActions();
        _bulletsCounter.SetBulletsCount(_bulletsAmount);
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
        if (_bulletsAmount < 1)
            return;

        _bulletsAmount--;
        _bulletsCounter.SetBulletsCount(_bulletsAmount);

        Debug.Log("Shot");
        _firePoint.SpawnBullet();
        _animator.Shot();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Vector3 GetCameraPosition()
    {
        if (_moveDirection == Vector2.zero)
        {
            return transform.position;
        }

        return _cameraPositionTransform.position;
    }
}
