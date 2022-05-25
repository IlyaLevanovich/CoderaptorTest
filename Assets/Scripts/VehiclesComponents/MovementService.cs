using UnityEngine;
using Zenject;

namespace Assets.Scripts.VehiclesComponents
{
    public class MovementService : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        private VehiclesSpawner _spawner;

        [Inject]
        private void Construct(VehiclesSpawner spawner)
        {
            this._spawner = spawner;
        }

        private void FixedUpdate()
        {
            foreach (var item in _spawner.VehiclesPool)
            {
                if (item.gameObject.activeInHierarchy)
                    item.Move(_movementSpeed);
            }
        }
    }
}