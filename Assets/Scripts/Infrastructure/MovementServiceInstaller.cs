using Assets.Scripts.VehiclesComponents;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class MovementServiceInstaller : MonoInstaller
    {
        [SerializeField] private VehiclesSpawner _spawner;

        public override void InstallBindings()
        {
            Container
                .Bind<VehiclesSpawner>()
                .FromInstance(_spawner)
                .AsSingle();
        }
    }
}