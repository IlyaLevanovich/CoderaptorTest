using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class VehiclesSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject[] _vehicles;

        public override void InstallBindings()
        {
            Container
                .Bind<GameObject[]>()
                .FromInstance(_vehicles)
                .AsSingle();
        }
    }
}