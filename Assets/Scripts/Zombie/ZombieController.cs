using UnityEngine;
using Zenject;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private ZombieAnimator _animator;

    [Header("HP settings")]
    [SerializeField] private MeshRenderer _hpBar;
    [SerializeField] private string _healthShaderParameterName = "_Health";

    [Header("Loot Settings")]
    [SerializeField] private Transform _lootSpawnPoint;

    private Vector3 _moveDirection;
    private ZombieData _data;
    private int _currentHealth;

    [Inject] private IZombiePool _zombiePool;
    [Inject] private ILootPool _lootPool;
    [Inject] private SoundController _soundController;

    public void Init(ZombieData data, Vector3 position, Vector3 characterPosition)
    {
        _data = data;
        _currentHealth = data.Health;

        SetHP(1f);

        transform.position = position;
        _moveDirection = (characterPosition - transform.position).normalized;
        _rigidBody.AddForce(_moveDirection * data.MoveSpeed);
        _animator.Run(_data.AnimatorController, _moveDirection);
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
        SpawnLoot();

        _soundController.Play();

        gameObject.SetActive(false);
        _zombiePool.FreeZombie(this);
    }

    private void SpawnLoot()
    {
        LootItem loot = _lootPool.GetLoot();
        loot.Initialize();
        loot.transform.position = _lootSpawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CharacterHurtBox character = collision.gameObject.GetComponent<CharacterHurtBox>();
        if (character == null)
            return;

        character.Death();
    }
}
