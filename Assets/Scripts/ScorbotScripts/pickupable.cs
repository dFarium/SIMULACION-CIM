using UnityEngine;

namespace ScorbotScripts
{
    public class Pickupable : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
    
    }
}
