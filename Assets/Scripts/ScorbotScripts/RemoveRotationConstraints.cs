using UnityEngine;

namespace ScorbotScripts
{
    public class RemoveRotationConstraints : MonoBehaviour
    {
        private Rigidbody[] _rigidbodies;
        public void Start()
        {
            _rigidbodies = GetComponentsInChildren<Rigidbody>();
        }

        public void RemoveConstraints()
        {
            foreach (Rigidbody rb in _rigidbodies )
            {
                rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
}
