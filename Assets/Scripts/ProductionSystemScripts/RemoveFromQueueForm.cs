using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RemoveFromQueueForm : MonoBehaviour
{
    [SerializeField] private ProductionManager productionManager;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TextMeshProUGUI statusText; 
    
    public void RemoveFromQueue()
    {
        if (dropdown.value != 0)
        {
            productionManager.RemoveFromQueue(dropdown.value);
            ResetForm();
            StartCoroutine(RemoveFromQueueSuccess());
        }
        else
        {
            ResetForm();
            StartCoroutine(RemoveFromQueueError());
        }
    }

    public void ResetForm()
    {
        dropdown.value = 0;
    }
    
    
    public IEnumerator RemoveFromQueueError()
    {
        statusText.color = Color.red;
        statusText.text = "Seleccione un item";
        yield return new WaitForSeconds(3);
        statusText.text = "";
    }
    
    public IEnumerator RemoveFromQueueSuccess()
    {
        statusText.color = Color.green;
        statusText.text = "Item removido de la cola";
        yield return new WaitForSeconds(3);
        statusText.text = "";
    }
    
}
