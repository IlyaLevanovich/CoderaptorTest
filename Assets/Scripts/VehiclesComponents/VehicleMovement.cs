using UnityEngine;

namespace Assets.Scripts.VehiclesComponents
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleMovement : MonoBehaviour
    {
        [SerializeField] private Transform[] _wheels;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(float moveSpeed)
        {
            //Checking the status of traffic lights, etc.
            //if(...red) return;

            var direction = Vector3.forward;
            _rigidbody.MovePosition(transform.position + moveSpeed * Time.fixedDeltaTime * direction);

            foreach (var wheel in _wheels)
            {
                wheel.rotation *= Quaternion.AngleAxis(moveSpeed, Vector3.right);
            }
        }
       
    }
}