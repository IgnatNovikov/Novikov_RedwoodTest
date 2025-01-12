using UnityEngine;
using TMPro;
using Zenject;

public class LootItem : MonoBehaviour
{
    [SerializeField] private int _minCount;
    [SerializeField] private int _maxCount;
    [SerializeField] private TextMeshPro _text;

    private int _count;

    [Inject] private ILootPool _lootPool;

    public void Initialize()
    {
        _count = Random.Range(_minCount, _maxCount);

        _text.text = _count.ToString();
    }

    public int GetCount()
    {
        return _count;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterPickUpBox character = collision.gameObject.GetComponent<CharacterPickUpBox>();
        if (character == null)
            return;

        character.AddBullets(_count);

        _lootPool.FreeLoot(this);
    }
}
