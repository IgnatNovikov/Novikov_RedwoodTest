using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Header("Character Settings")]
    [SerializeField] private Character _character;

    [Header("Zombie Settings")]
    [SerializeField] private GameObject _zombiePrefab;
    [SerializeField] private ZombieSpawnerTransforms _zombieSpawnerTransforms;
    [SerializeField] private ZombieSpawner _zombieSpawner;

    [Header("Bullet Settings")]
    [SerializeField] private Transform _bulletPoolTransform;
    [SerializeField] private BulletController _bulletPrefab;
    [SerializeField] private BulletSpawner _bulletSpawner;

    [Header("Loot Settings")]
    [SerializeField] private GameObject _lootItem;
    [SerializeField] private LootSpawner _lootSpawner;

    [Header("UI")]
    [SerializeField] private BulletsCounter _bulletsCounter;
    [SerializeField] private GameOverScreen _gameOverScreen;

    [Header("Sounds")]
    [SerializeField] private SoundController _soundController;

    public override void InstallBindings()
    {
        Container.BindFactory<ZombieController, ZombieFactory>().FromComponentInNewPrefab(_zombiePrefab);
        Container.Bind<ISpawner>().To<ZombieSpawnerTransforms>().FromInstance(_zombieSpawnerTransforms).AsSingle();
        Container.Bind<ICharacter>().To<Character>().FromInstance(_character).AsSingle();
        Container.Bind<IZombiePool>().To<ZombieSpawner>().FromInstance(_zombieSpawner);

        Container.BindFactory<BulletController, BulletFactory>().FromComponentInNewPrefab(_bulletPrefab).UnderTransform(_bulletPoolTransform);

        Container.Bind<BulletsCounter>().FromInstance(_bulletsCounter);
        Container.Bind<IBulletPool>().To<BulletSpawner>().FromInstance(_bulletSpawner);

        Container.BindFactory<LootItem, LootFactory>().FromComponentInNewPrefab(_lootItem).UnderTransform(_lootSpawner.transform);
        Container.Bind<ILootPool>().To<LootSpawner>().FromInstance(_lootSpawner);

        Container.Bind<GameOverScreen>().FromInstance(_gameOverScreen);

        Container.Bind<SoundController>().FromInstance(_soundController);
    }
}
