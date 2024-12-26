using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private UnityEngine.CharacterController _controller;
    [SerializeField] private ZombieAnimator _animator;

    [Header("HP settings")]
    [SerializeField] private MeshRenderer _hpBar;
    [SerializeField] private string _healthShaderParameterName = "_Health";

    private Vector3 _moveDirection;
    private ZombieData _data;
    private int _currentHealth;

    [Inject] private IZombiePool _zombiePool;

    public void Init(ZombieData data, Vector3 position, Vector3 characterPosition)
    {
        _data = data;
        _currentHealth = data.Health;

        SetHP(1f);

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

    private void SetHP(float value)
    {
        value = value < 0f ? 0f : value;
        value = value > 1f ? 1f : value;

        _hpBar.material.SetFloat(_healthShaderParameterName, value);
    }

    public void TakeHit()
    {
        _currentHealth--;
        SetHP((float)_currentHealth / _data.Health);
        if (_currentHealth < 1)
            Death();
    }

    private void Death()
    {
        gameObject.SetActive(false);
        _zombiePool.FreeZombie(this);
    }
}
