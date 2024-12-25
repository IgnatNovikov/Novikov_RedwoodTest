using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private UnityEngine.CharacterController _controller;
    [SerializeField] private ZombieAnimator _animator;

    private Vector3 _moveDirection;
    private ZombieData _data;

    public void Init(ZombieData data, Vector3 position, Vector3 characterPosition)
    {
        _data = data;

        _controller.enabled = false;
        transform.position = position;
        _controller.enabled = true;
        _moveDirection = (characterPosition - transform.position).normalized;
        _animator.Run(_data.AnimatorController, _moveDirection);
    }

    private void FixedUpdate()
    {
        if (_data == null)
            return;

        _controller.Move(_moveDirection * _data.MoveSpeed);
    }
}
