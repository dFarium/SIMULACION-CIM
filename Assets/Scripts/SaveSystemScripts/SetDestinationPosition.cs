using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetDestinationPosition : MonoBehaviour
{
    [SerializeField] private int stationNumber;
    [SerializeField] private int saveNumber;
    
    [SerializeField] private TextMeshProUGUI controlMainText;
    [SerializeField] private TextMeshProUGUI auxiliarText;
    [SerializeField] private TextMeshProUGUI saveText;
    
    private string defaultControlText = "awaiting  action";
    
    [SerializeField] private List<Button> interactableButtons = new List<Button>();
    [SerializeField] private List<GameObject> numericButtons = new List<GameObject>();
    [SerializeField] private List<GameObject> hideButtons = new List<GameObject>();

    [SerializeField] private Tweener tweenerScript;

    [SerializeField] private GameObject destino;
    
    private bool isRecord;

    public void RecordButton()
    {
        isRecord = true;
        ToggleButton();
    }
    
    public void GoPositionButton()
    {
        //Debug.Log("");
        isRecord = false;
        ToggleButton();
    }
    
    public void ToggleButton()
    {
        if (isRecord)
        {
            auxiliarText.text = "Record Position ";   
        }
        else
        {
            auxiliarText.text = "Go Position ";
        }
        saveText.text = "_";
        
        controlMainText.gameObject.SetActive(false);
        saveText.gameObject.SetActive(true);
        auxiliarText.gameObject.SetActive(true);
        
        foreach (Button buttons  in interactableButtons)
        {
            buttons.interactable=false;
        }
        
        foreach (GameObject hideButton in hideButtons)
        {
            hideButton.SetActive(false);
        }
        
        foreach (GameObject numericButton in numericButtons)
        {
            numericButton.SetActive(true);
        }
    }
    
    public void Cancel()
    {
        controlMainText.text = defaultControlText;
        controlMainText.gameObject.SetActive(true);
        saveText.gameObject.SetActive(false);
        auxiliarText.gameObject.SetActive(false);
        
        foreach (Button buttons  in interactableButtons)
        {
            buttons.interactable=true;
        }
        
        foreach (GameObject hideButton in hideButtons)
        {
            hideButton.SetActive(true);
        }
        
        foreach (GameObject numericButton in numericButtons)
        {
            numericButton.SetActive(false);
        }
    }
    
    public void Confirm()
    {
        //comprueba que el valor esta dentro del rango
        int.TryParse(saveText.text, out int index);
        if (index>0 && index<101)
        {
            Debug.Log("ejecutando confirmacion, isRecord: "+isRecord);
            saveNumber = index;
            foreach (Button buttons  in interactableButtons)
            {
                buttons.interactable=true;
            }
        
            foreach (GameObject hideButton in hideButtons)
            {
                hideButton.SetActive(true);
            }
        
            foreach (GameObject numericButton in numericButtons)
            {
                numericButton.SetActive(false);
            }
            
            controlMainText.text = defaultControlText;
            
            if (isRecord)
            {
                SavePosition();
            }
            else
            {
                LoadAndSetPosition(); //ejecutarse desde Destination
                tweenerScript.PlaySequence(); //ejecutarse desde IK
            }
            controlMainText.gameObject.SetActive(true);
            saveText.gameObject.SetActive(false);
            auxiliarText.gameObject.SetActive(false);
        }
        else
        {
            if (isRecord)
            {
                Debug.Log("error save value");
                controlMainText.text = "ERROR SAVE VALUE";
            }
            else
            {
                Debug.Log("error load value");
                controlMainText.text = "ERROR LOAD VALUE";
            }
            
            controlMainText.gameObject.SetActive(true);
            saveText.gameObject.SetActive(false);
            auxiliarText.gameObject.SetActive(false);
            StartCoroutine(textDelay(1));
        }
        
    }
    
    private IEnumerator textDelay(int numero)
    {
        yield return new WaitForSeconds(numero);
        ToggleButton();
    }
    
    
    public void LoadAndSetPosition()
    {
        int.TryParse(saveText.text, out saveNumber);
        Vector3? newPosition = PositionManager.LoadPosition(stationNumber,saveNumber);
        if (newPosition == null)
        {
            return;
        }
        Debug.Log("new position: "+newPosition);
        destino.transform.position = (Vector3)newPosition;
    }
    
    public void SavePosition()
    {
        int.TryParse(saveText.text, out saveNumber);
        PositionManager.SavePosition(stationNumber,saveNumber,transform.position);
    }
}
