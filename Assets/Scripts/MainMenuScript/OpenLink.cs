using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class OpenLink : MonoBehaviour
{

    [SerializeField] private string link;
    
    public void OpenLinkInBrowser()
    {
        Application.OpenURL(link);
    }
}
