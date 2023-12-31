using System;
using UnityEngine;

namespace ScorbotScripts
{
    public class PickUpObject : MonoBehaviour
    {
        public GameObject _pickedObject;
        public GameObject _targetGameObject;
        public bool _isObjectPicked;
        private bool _canPickUp = true;
        private Animator gripAnimator;
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");
        private static readonly int HasMaterial = Animator.StringToHash("HasMaterial");

        private void Start()
        {
            gripAnimator = GetComponentInParent<Animator>();
            if(!gripAnimator) return;
            if (gripAnimator.name == "Mano")
            {
                gripAnimator.SetBool("IsOpen", _canPickUp);
            }
        }

        public void PickUpToggle()
        {
            //Si las pinzas estan cerradas, se abren y sueltan objeto si tienen uno
            if (!_canPickUp)
            {
                Debug.Log("ABRIENDO PINZAS");
                _canPickUp = true;
                if (gripAnimator.name == "Mano")
                {
                    gripAnimator.SetBool("IsOpen", _canPickUp);
                }
                DropObject();
                return;
            }

            //Si hay objeto en el rango de las pinzas, se toma
            if (_targetGameObject && !_isObjectPicked)
            {
                Debug.Log("TOMANDO OBJETO,CERRANDO PINZAS");
                _canPickUp = false;
                if (gripAnimator.name == "Mano")
                {
                    gripAnimator.SetBool("IsOpen", _canPickUp);
                    gripAnimator.SetBool("HasMaterial", true);
                }
                PickUp();
                return;
            }

            //Si no hay objecto en rango, se cierran las pinzas
            Debug.Log("NADA QUE TOMAR,CERRANDO PINZAS");
            _canPickUp = false;
            if (gripAnimator.name == "Mano")
            {
                gripAnimator.SetBool("IsOpen", _canPickUp);
                gripAnimator.SetBool("HasMaterial", false);
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
            if (other.gameObject == _targetGameObject)
            {
                _targetGameObject = null;
            }
        }

        private void PickUp()
        {
            if (!_isObjectPicked && _targetGameObject != null)
            {
                _isObjectPicked = true;
                _pickedObject = _targetGameObject;
                _pickedObject.GetComponent<Pickupable>().PickUp(transform);
            }

            Debug.Log("Siendo pickeado por " + gameObject.name);
        }

        private void DropObject()
        {
            _isObjectPicked = false;
            if (_pickedObject)
            {
                _pickedObject.GetComponent<Pickupable>().Drop();
            }

            _pickedObject = null;
        }
    }
}