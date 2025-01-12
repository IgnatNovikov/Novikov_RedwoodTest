using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LootSpawner : MonoBehaviour, ILootPool
{
    private Stack<LootItem> _freeLoot = new Stack<LootItem>();
    private List<LootItem> _usedLoot = new List<LootItem>();

    [Inject] private LootFactory _lootFactory;

    public LootItem GetLoot()
    {
        LootItem item;
        if (_freeLoot.Count > 0)
        {
            item = _freeLoot.Pop();
            item.gameObject.SetActive(true);
        }
        else
        {
            item = _lootFactory.Create().GetComponent<LootItem>();
        }

        _usedLoot.Add(item);

        return item;
    }

    public void FreeLoot(LootItem item)
    {
        if (_freeLoot.Contains(item))
            return;

        item.gameObject.SetActive(false);
        _usedLoot.Remove(item);
        _freeLoot.Push(item);
    }

    public void ClearPool()
    {
        int count = _usedLoot.Count - 1;
        for (int i = count; i >= 0; i--)
        {
            LootItem loot = _usedLoot[i];

            loot.gameObject.SetActive(false);
            _freeLoot.Push(loot);
            _usedLoot.Remove(loot);
        }
    }
}
