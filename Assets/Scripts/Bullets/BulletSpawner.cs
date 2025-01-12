using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BulletSpawner : MonoBehaviour, IBulletPool
{
    private Stack<BulletController> _freeBullets = new Stack<BulletController>();
    private List<BulletController> _usedBullets = new List<BulletController>();

    [Inject] private BulletFactory _bulletFactory;
    [Inject] private ICharacter _characterPosition;

    public void SpawnBullet()
    {
        BulletController bullet = GetBullet();

        bullet.transform.position = transform.position;
        bullet.Shoot((transform.position - _characterPosition.GetPosition()).normalized);
    }

    private BulletController GetBullet()
    {
        BulletController bullet;
        if (_freeBullets.Count > 0)
        {
            bullet = _freeBullets.Pop();
            bullet.gameObject.SetActive(true);
        }
        else
        {
            bullet = _bulletFactory.Create().GetComponent<BulletController>();
        }

        _usedBullets.Add(bullet);

        return bullet;
    }

    public void FreeBullet(BulletController bullet)
    {
        if (_freeBullets.Contains(bullet))
            return;

        _usedBullets.Remove(bullet);
        _freeBullets.Push(bullet);
    }

    public void ClearPool()
    {
        int count = _usedBullets.Count - 1;
        for (int i = count; i >= 0; i--)
        {
            BulletController bullet = _usedBullets[i];

            bullet.gameObject.SetActive(false);
            _freeBullets.Push(bullet);
            _usedBullets.Remove(bullet);
        }
    }
}
