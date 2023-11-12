using System;
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
        
        public void PickUp(Transform parent)
        {
            _rigidbody.isKinematic = true;
            //targetTransform.localPosition = Vector3.zero;
            transform.SetParent(parent);
            //transform.localPosition = Vector3.zero;
        }
        
        public void Drop()
        {
            _rigidbody.isKinematic = false;
            transform.parent = null;
        }
        
    }
}
