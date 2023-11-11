using System;
using UnityEngine;

namespace ScorbotScripts
{
    public class PickUpObject : MonoBehaviour
    {
        private GameObject _pickedObject;
        public GameObject _targetGameObject;
        private bool _isObjectPicked;
        private bool _canPickUp = true;
        private Animator _animator;
        private static readonly int IsOpen = Animator.StringToHash("IsOpen");
        private static readonly int HasMaterial = Animator.StringToHash("HasMaterial");

        private void Start()
        {
            _animator = GetComponentInParent<Animator>();
            _animator.SetBool(IsOpen, _canPickUp);
        }

        public void PickUpToggle()
        {
            //Si las pinzas estan cerradas, se abren y sueltan objeto si tienen uno
            if (!_canPickUp)
            {
                Debug.Log("ABRIENDO PINZAS");
                _canPickUp = true;
                _animator.SetBool(IsOpen, _canPickUp);
                DropObject();
                return;
            }

            //Si hay objeto en el rango de las pinzas, se toma
            if (_targetGameObject && !_isObjectPicked)
            {
                Debug.Log("TOMANDO OBJETO,CERRANDO PINZAS");
                _canPickUp = false;
                _animator.SetBool(IsOpen, _canPickUp);
                _animator.SetBool(HasMaterial, true);
                PickUp();
                return;
            }

            //Si no hay objecto en rango, se cierran las pinzas
            Debug.Log("NADA QUE TOMAR,CERRANDO PINZAS");
            _canPickUp = false;
            _animator.SetBool(IsOpen, _canPickUp);
            _animator.SetBool(HasMaterial, false);
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

        public void test()
        {
            Debug.Log("si se puede");
        }
    }
}