using UnityEngine;

namespace ScorbotScripts
{
    public class PickUpObject : MonoBehaviour
    {
        private GameObject _pickedObject;
        private GameObject _targetGameObject;
        private bool _isObjectPicked;

        private void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                if (_isObjectPicked)
                {
                    Debug.Log(("SOLTANDO OBJETO"));
                    DropObject();
                }
                else if (_targetGameObject && !_isObjectPicked)
                {
                    Debug.Log("TOMANDO OBJETO");
                    PickUp();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isObjectPicked && other.TryGetComponent(out Pickupable pickupableObject))
            {
                _targetGameObject = other.gameObject;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _targetGameObject = null;
        }

        public void PickUp()
        {
            if (!_isObjectPicked && _targetGameObject != null)
            {
                _isObjectPicked = true;
                _pickedObject = _targetGameObject;
                _pickedObject.transform.parent = transform;
            }
        }

        public void DropObject()
        {
            _isObjectPicked = false;
            _pickedObject.transform.parent = null;
            _pickedObject = null;
        }
    }
}