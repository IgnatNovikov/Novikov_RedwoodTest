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

    public override void InstallBindings()
    {
        Container.BindFactory<ZombieController, ZombieFactory>().FromComponentInNewPrefab(_zombiePrefab);
        Container.Bind<ISpawner>().To<ZombieSpawnerTransforms>().FromInstance(_zombieSpawnerTransforms).AsSingle();
        Container.Bind<ICharacterPosition>().To<CharacterController>().FromInstance(_character).AsSingle();
        Container.Bind<IZombiePool>().To<ZombieSpawner>().FromInstance(_zombieSpawner);
    }
}
