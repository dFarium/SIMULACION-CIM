using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PropertyAttribute = UnityEngine.PropertyAttribute;


public class FoldoutAttribute : PropertyAttribute
{
    public string Name { get; private set; }
    public bool FoldedOut { get; set; }

    public FoldoutAttribute(string name)
    {
        Name = name;
        FoldedOut = true; // Definir si se comienza desplegado o no
    }

}
