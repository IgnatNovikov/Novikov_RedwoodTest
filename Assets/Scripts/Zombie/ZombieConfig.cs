using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieConfig", menuName = "Configs/ZombieConfig", order = 0)]
public class ZombieConfig : ScriptableObject
{
    [SerializeField] private List<ZombieData> _zombies;

    public ZombieData GetZombieData()
    {
        return _zombies[Random.Range(0, _zombies.Count)];
    }
}
