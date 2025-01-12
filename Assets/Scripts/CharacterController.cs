using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class CharacterController : MonoBehaviour, ICharacter
{
    [SerializeField] private UnityEngine.CharacterController _controller;
    [SerializeField] private CharacterAnimator _animator;
    [SerializeField] private Transform _cameraPositionTransform;
    [SerializeField] private int _bulletsAmount;

    [Header("Character parameters")]
    [SerializeField, Min(0)] private float _movementSpeed;

    [Header("Bullets")]
    [SerializeField] private BulletSpawner _firePoint;
    [SerializeField] private Timer _shotTimer;

    private InputActions _inputActions;
    private InputAction _move;
    private InputAction _shoot;

    private Vector2 _moveDirection;

    private int _currentBullets;

    private bool _shooting = false;

    [Inject] private BulletsCounter _bulletsCounter;
    [Inject] private GameOverScreen _gameOverScreen;

    private void Awake()
    {
        _inputActions = new InputActions();
        _currentBullets = _bulletsAmount;
        _bulletsCounter.SetBulletsCount(_bulletsAmount);

        _shotTimer.OnTimeAction += Shoot;
    }

    private void OnEnable()
    {
        _move = _inputActions.PlayerActions.Move;
        _move.Enable();

        _shoot = _inputActions.PlayerActions.Shot;
        _shoot.Enable();
        _shoot.started += OnBurstStarted;
        _shoot.canceled += OnBurstCanceled;
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

    private void OnBurstStarted(InputAction.CallbackContext callback)
    {
        _shooting = true;

        Shoot();
        _shotTimer.StartTimer();
    }

    private void Shoot()
    {
        if (!_shooting)
        {
            _animator.Shot(false);
            return;
        }

        if (_currentBullets < 1)
            return;

        _currentBullets--;
        _bulletsCounter.SetBulletsCount(_currentBullets);

        _firePoint.SpawnBullet();
        _animator.Shot(true);
    }

    private void OnBurstCanceled(InputAction.CallbackContext callback)
    {
        _shooting = false;
        _shotTimer.StopTimer();
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

    public void AddBullets(int bulletsCount)
    {
        _currentBullets += bulletsCount;
        _bulletsCounter.SetBulletsCount(_currentBullets);
    }

    public void Death()
    {
        _gameOverScreen.Show();
    }

    public void Refresh()
    {
        _currentBullets = _bulletsAmount;
        _bulletsCounter.SetBulletsCount(_currentBullets);
    }
}
