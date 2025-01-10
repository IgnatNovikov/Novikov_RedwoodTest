using UnityEngine;
using Zenject;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Timer _timer;
    [SerializeField] private float _speed;


    [Inject] private IBulletPool _bulletPool;

    public void Shoot(Vector3 direction)
    {
        _rigidBody.AddForce(direction * _speed);

        _timer.OnTimeAction += FreeBullet;
        _timer.StartTimer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ZombieHurtbox zombie = collision.GetComponent<ZombieHurtbox>();
        if (zombie == null)
            return;

        zombie.TakeHit();
        gameObject.SetActive(false);
        _timer.StopTimer();
        _bulletPool.FreeBullet(this);
    }

    private void FreeBullet()
    {
        gameObject.SetActive(false);
        _timer.StopTimer();
        _bulletPool.FreeBullet(this);
    }
}
