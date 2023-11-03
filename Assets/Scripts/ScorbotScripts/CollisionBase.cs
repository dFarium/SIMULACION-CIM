using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBase : MonoBehaviour
{
    public Material highlightMaterial;
    public bool highlightCollision;

    public void ToggleHighlightCollision()
    {
        highlightCollision = !highlightCollision;
    }
}