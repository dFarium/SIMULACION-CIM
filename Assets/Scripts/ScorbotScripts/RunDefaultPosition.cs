using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class RunDefaultPosition : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI controlMainText;
    [SerializeField] private TextMeshProUGUI auxiliarText;
    [FormerlySerializedAs("saveText")] [SerializeField] private TextMeshProUGUI numberText;
    
    private string defaultControlText = "awaiting  action";
    
    [SerializeField] private List<Button> interactableButtons = new List<Button>();
    [SerializeField] private List<GameObject> numericButtons = new List<GameObject>();
    [SerializeField] private List<GameObject> hideButtons = new List<GameObject>();

    [SerializeField] private Tweener tweenerScript;

    [SerializeField] private GameObject defaultPositionObject;
    //Variable que afecta al tweener
    [SerializeField] private GameObject destino;
    
    public void RunButton()
    {
        
        auxiliarText.text = "Run ";
        numberText.text = "_";
        
        controlMainText.gameObject.SetActive(false);
        numberText.gameObject.SetActive(true);
        auxiliarText.gameObject.SetActive(true);
        
        foreach (Button buttons  in interactableButtons)
        {
            EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
            if (eventButtonTrigger != null)
            {
                eventButtonTrigger.enabled = false;
            }
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
        foreach (Button buttons  in interactableButtons)
        {
            EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
            if (eventButtonTrigger != null)
            {
                eventButtonTrigger.enabled = true;
            }
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

        controlMainText.text = "Aborted";
        StartCoroutine(TextDelay(1));
        controlMainText.gameObject.SetActive(true);
        numberText.gameObject.SetActive(false);
        auxiliarText.gameObject.SetActive(false);
    }
    
    public void Confirm()
    {
        //comprueba que el valor esta dentro del rango
        int.TryParse(numberText.text, out int index);
        if (index==0)
        {
            foreach (Button buttons  in interactableButtons)
            {
                EventTrigger eventButtonTrigger = buttons.GetComponent<EventTrigger>();
                if (eventButtonTrigger != null)
                {
                    eventButtonTrigger.enabled = true;
                }
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

            destino.transform.position = defaultPositionObject.transform.position;
            tweenerScript.PlaySequence(); //ejecutarse desde IK
            controlMainText.gameObject.SetActive(true);
            numberText.gameObject.SetActive(false);
            auxiliarText.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("error load value");
            controlMainText.text = "NO PROGRAM DATA";
            
            controlMainText.gameObject.SetActive(true);
            numberText.gameObject.SetActive(false);
            auxiliarText.gameObject.SetActive(false);
            StartCoroutine(ErrorDelay(1));
        }
        
    }
    
    private IEnumerator ErrorDelay(int numero) 
    {
        yield return new WaitForSeconds(numero);
        RunButton();
    }
    
    private IEnumerator TextDelay(int numero)
    {
        yield return new WaitForSeconds(numero);
        controlMainText.text = defaultControlText;
    }
    
}
