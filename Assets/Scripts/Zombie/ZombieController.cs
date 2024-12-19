using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private UnityEngine.CharacterController _controller;
    //[SerializeField] private ZombieAnimator _animator;

    [Header("Character parameters")]
    [SerializeField] private float _movementSpeed;

    private Vector2 _moveDirection;

    public void Init(Vector2 direction)
    {
        _moveDirection = direction;
        //_animator.Run(_moveDirection);
    }

    private void FixedUpdate()
    {
        _controller.Move(_moveDirection * _movementSpeed);
    }
}
