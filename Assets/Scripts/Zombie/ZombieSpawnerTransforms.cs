using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnerTransforms : MonoBehaviour, ISpawner
{
    [SerializeField] private List<Transform> _spawners;
    public List<Transform> Spawners => _spawners;

    public Transform GetSpawner()
    {
        return _spawners[Random.Range(0, _spawners.Count)];
    }
}
