using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private ZombieConfig _zombieConfig;
    [SerializeField] private int _minDelay;
    [SerializeField] private int _maxDelay;

    private Stack<ZombieController> _freeZombies = new Stack<ZombieController>();
    private List<ZombieController> _usedZombies = new List<ZombieController>();

    private Sequence _sequence;

    [Inject] private ZombieFactory _zombieFactory;
    [Inject] private ISpawner _spawnerTransforms;
    [Inject] private ICharacterPosition _characterPosition;

    private void Start()
    {
        SpawnZombie();
    }

    public void SpawnZombie()
    {
        ZombieController zombie = GetZombie();

        Vector3 pos = _spawnerTransforms.GetSpawner().position;
        pos.y = transform.position.y;

        zombie.Init(_zombieConfig.GetZombieData(), pos, _characterPosition.GetPosition());
        zombie.transform.SetParent(transform);

        _sequence = null;
        _sequence = DOTween.Sequence();
        //int delay = Random.Range(_minDelay, _maxDelay);
        _sequence.SetDelay(Random.Range(_minDelay, _maxDelay));
        _sequence.AppendCallback(SpawnZombie);
        _sequence.Play();
    }

    private ZombieController GetZombie()
    {
        ZombieController zombie;
        if (_freeZombies.Count > 0)
        {
            zombie = _freeZombies.Pop();
        }
        else
        {
            zombie = _zombieFactory.Create().GetComponent<ZombieController>();
        }

        _usedZombies.Add(zombie);

        return zombie;
    }

    public void FreeZombie(ZombieController zombie)
    {
        _usedZombies.Remove(zombie);
        _freeZombies.Push(zombie);
    }
}
