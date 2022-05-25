using Assets.Scripts.Environment;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Utilities
{
    public class CameraFollow : MonoBehaviour
    {
        private const float _offset = 5;
        private VehicleSelector _selector;

        [Inject]
        private void Construct(VehicleSelector selector)
        {
            this._selector = selector;
        }

        private void LateUpdate()
        {
            var target = _selector.SelectedVehicle;
            if (target == null) return;

            var adjustedPosition = new Vector3(

                transform.position.x, 
                transform.position.y, 
                target.transform.position.z + _offset

            );

            transform.position = Vector3.Lerp(transform.position, adjustedPosition, Time.deltaTime);
        }
    }
}