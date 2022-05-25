using Assets.Scripts.Environment;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private VehicleSelector _vehicleSelector;

        public override void InstallBindings()
        {
            Container
                .Bind<VehicleSelector>()
                .FromInstance(_vehicleSelector)
                .AsSingle();
        }
    }
}