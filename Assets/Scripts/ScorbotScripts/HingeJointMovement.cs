using UnityEngine;

namespace ScorbotScripts
{
    public class HingeJointMovement : MonoBehaviour
    {
        private HingeJoint _hinge;
        private Rigidbody _rigidbody;
        [SerializeField] private float _rotationSpeed;
        private JointMotor _hingeMotor;

        private void Start()
        {
            //Iniciar variables
            _rigidbody = GetComponent<Rigidbody>();
            _hinge = GetComponent<HingeJoint>();
            //Preparacion del motor para la articulacion
            JointMotor hingeMotor = _hinge.motor;
            hingeMotor.force = 100;
            _hinge.useMotor = true;
            _hinge.motor = hingeMotor;
        }

        private void Update()
        {
            if (Input.GetKeyDown("q"))
            {
                Debug.Log("MOVIENDO ROBOT EN TRUE...");
                Rotate(true);
            }

            if (Input.GetKeyDown("e"))
            {
                Debug.Log("MOVIENDO ROBOT EN FALSE...");
                Rotate(false);
            }

            if (Input.GetKeyUp("w"))
            {
                Debug.Log("DETENIENDO ROBOT");
                StopRotating();
            }
        }

        //Mover robot
        public void Rotate(bool rotation)
        {
            int rotationDirection = rotation ? 1 : -1;
            JointMotor hingeMotor = _hinge.motor;
            hingeMotor.targetVelocity = _rotationSpeed * rotationDirection;
            _hinge.motor = hingeMotor;
        }

        public void StopRotating()
        {
            JointMotor hingeMotor = _hinge.motor;
            hingeMotor.targetVelocity = 0f;
            _hinge.motor = hingeMotor;
        }

        public void FreezeXRotationAxis()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
        }

        public void FreezeYRotationAxis()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
        }

        public void FreezeZRotationAxis()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }
}