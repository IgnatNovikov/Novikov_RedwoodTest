using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [Header("Character Settings")]
    [SerializeField] private CharacterController _character;

    [Header("Zombie Settings")]
    [SerializeField] private GameObject _zombiePrefab;
    [SerializeField] private ZombieSpawnerTransforms _zombieSpawnerTransforms;
    [SerializeField] private ZombieSpawner _zombieSpawner;

    [Header("Bullet Settings")]
    [SerializeField] private Transform _bulletPoolTransform;
    [SerializeField] private BulletController _bulletPrefab;

    [Header("UI")]
    [SerializeField] private BulletsCounter _bulletsCounter;

    public override void InstallBindings()
    {
        Container.BindFactory<ZombieController, ZombieFactory>().FromComponentInNewPrefab(_zombiePrefab);
        Container.Bind<ISpawner>().To<ZombieSpawnerTransforms>().FromInstance(_zombieSpawnerTransforms).AsSingle();
        Container.Bind<ICharacterPosition>().To<CharacterController>().FromInstance(_character).AsSingle();
        Container.Bind<IZombiePool>().To<ZombieSpawner>().FromInstance(_zombieSpawner);

        Container.BindFactory<BulletController, BulletFactory>().FromComponentInNewPrefab(_bulletPrefab).UnderTransform(_bulletPoolTransform);

        Container.Bind<BulletsCounter>().FromInstance(_bulletsCounter);
    }
}
