using System;
using UnityEngine;

namespace ScorbotScripts
{
    public class Pickupable : MonoBehaviour
    {
        [SerializeField] private bool isAnimated;
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void PickUp(Transform parent)
        {
            if (_rigidbody != null) _rigidbody.isKinematic = true;
            transform.SetParent(parent);
            //transform.localPosition = Vector3.zero;
        }

        public void Drop()
        {
            if (_rigidbody != null) _rigidbody.isKinematic = false;
            transform.parent = null;
        }
    }
}