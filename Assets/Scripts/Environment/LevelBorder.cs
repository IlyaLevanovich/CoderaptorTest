using UnityEngine;

namespace Assets.Scripts.Environment
{
    [RequireComponent(typeof(Collider))]
    public class LevelBorder : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.SetActive(false);
        }
    }
}