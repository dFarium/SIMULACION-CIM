using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeJointMovement : MonoBehaviour
{
    private HingeJoint hinge;
    private void Start()
    {
       hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
