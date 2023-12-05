using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisableSortingDropdown : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    
    
    public void DisableDropdown()
    {
        dropdown.interactable = false;
    }
}
