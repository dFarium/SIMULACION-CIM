using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBase : MonoBehaviour
{
    public delegate void CollisionShaderToggledAction();

    public static event CollisionShaderToggledAction OnToggleCollisionShaderToggled;


    public static void InvokeCollisionShaderToggledEvent()
    {
        OnToggleCollisionShaderToggled?.Invoke();
    }
}