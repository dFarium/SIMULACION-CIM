using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ScorbotScripts
{
    public class HingeJointMovement : MonoBehaviour
    {
        private HingeJoint _hinge;
        private Rigidbody _rigidbody;
        [SerializeField] private TextMeshProUGUI speedText;
        [SerializeField] private int _rotationSpeed;
        [SerializeField] private float baseSpeed;
        private JointMotor _hingeMotor;

        [SerializeField] private HybridInverseKinematicsNode IKProcesor;
        [SerializeField] private GameObject IKTarget;
        [SerializeField] private GameObject Mano;

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

        //Mover robot
        public void Rotate(bool rotation)
        {
            IKProcesor.enabled = false;
            int rotationDirection = rotation ? 1 : -1;
            JointMotor hingeMotor = _hinge.motor;
            int.TryParse(speedText.text, out _rotationSpeed);
            hingeMotor.targetVelocity = _rotationSpeed * baseSpeed * rotationDirection;
            _hinge.motor = hingeMotor;
        }

        public void StopRotating()
        {
            JointMotor hingeMotor = _hinge.motor;
            hingeMotor.targetVelocity = 0f;
            _hinge.motor = hingeMotor;
            IKTarget.transform.position = Mano.transform.position;
            IKProcesor.enabled = true;
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