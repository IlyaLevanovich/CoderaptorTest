using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.VehiclesComponents
{
    public class VehiclesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _delayBetweenSpawn;

        private const int _factor = 5;

        private GameObject[] _vehicles;
        private VehicleMovement[] _vehiclesPool;

        public VehicleMovement[] VehiclesPool => _vehiclesPool;

        [Inject]
        private void Construct(GameObject[] vehicles)
        {
            this._vehicles = vehicles;
            CreateVehiclesPool();

            StartCoroutine(SpawnVehicles());
        }

        private void CreateVehiclesPool()
        {
            _vehiclesPool = new VehicleMovement[_vehicles.Length * _factor];

            for (int i = 0; i < _vehiclesPool.Length; i++)
            {
                int index = i / _factor;
                

                var current = Instantiate(_vehicles[index]);
                current.transform.SetParent(transform);
                current.transform.localPosition = Vector3.zero;
                current.SetActive(false);

                _vehiclesPool[i] = current.GetComponent<VehicleMovement>();

            }
        }

        private IEnumerator SpawnVehicles()
        {
            while(Application.IsPlaying(this))
            {
                yield return new WaitForSeconds(_delayBetweenSpawn);

                var current = GetAvailvableVehicle();

                current.transform.localPosition = _spawnPoint.position;
                current.SetActive(true);
            }
        }

        private GameObject GetAvailvableVehicle()
        {
            GameObject result = null;

            while(result == null)
            {
                int random = Random.Range(0, _vehiclesPool.Length);
                if (!_vehiclesPool[random].gameObject.activeInHierarchy)
                    result = _vehiclesPool[random].gameObject;
            }

            return result;
        }

    }
}