using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SpeedValue : MonoBehaviour
{
    [SerializeField] private Text speedText;
    [SerializeField] private Text botoneraString;
    private string currentText = "_";
    private string previousText;
    
    [SerializeField] private List<Button> interactableButtons = new List<Button>();
    [SerializeField] private List<GameObject> numericButtons = new List<GameObject>();
    [SerializeField] private List<GameObject> hideButtons = new List<GameObject>();


    public void SpeedModifier()
    {
        previousText = speedText.text;
        
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
        
        speedText.text = currentText;
    }

    public void ChangeSpeed(string number)
    {
        if (speedText.text == "_")
        {
            speedText.text = number;
        }
        else
        {
            speedText.text = speedText.text + number;
        }
        
    }

    public void Cancel()
    {
        speedText.text = previousText;
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
        if (true )
        {
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
        else
        {
            
        }
        
        
    }
}
