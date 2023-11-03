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
    [SerializeField] private Text auxiliarText;
    private string currentText = "_";
    private string previousText;
    
    [SerializeField] private List<Button> interactableButtons = new List<Button>();
    [SerializeField] private List<GameObject> numericButtons = new List<GameObject>();
    [SerializeField] private List<GameObject> hideButtons = new List<GameObject>();

    /* Funcion ejecutada por el boton "Speed" en la botonera
     * Desactiva la funcionalidad de los botones en la lista "interactableButtons"
     * Muestra en pantalla los botones listados en "numericButtons"
     * Esconde los botones listados en "hideButtons" para evitar la superposicion 
     */
    public void SpeedModifier()
    {
        previousText = speedText.text;
        botoneraString.gameObject.SetActive(false);
        speedText.gameObject.SetActive(true);
        auxiliarText.text = "enter speed";
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
        
        speedText.text = currentText;
    }

    // Permite actualizar el string (o texto) que muesrta en la botonera el valor actual de la speed
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

    // Deshace los cambios en la variable speedText y ejecuta "Confirm" 
     
    public void Cancel()
    {
        speedText.text = previousText;
        Confirm();
    }
    
    /* Verifica que el valor de speed este dentro del limite 1~100
     * Activa los botones desactivados y esconde los botones numericos
     * En caso de error, muestra mensaje en botonera
     */
    public void Confirm()
    {
        int.TryParse(speedText.text, out int flag);
        if (flag>0 && flag<101)
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
            botoneraString.gameObject.SetActive(true);
            speedText.gameObject.SetActive(false);
            auxiliarText.gameObject.SetActive(false);
            botoneraString.text = "LOADING...";
        }
        else
        {
            Debug.Log("error speed");
            botoneraString.gameObject.SetActive(true);
            speedText.gameObject.SetActive(false);
            auxiliarText.gameObject.SetActive(false);
            speedText.text = previousText;
            botoneraString.text = "ERROR SPEED INVALIDA";
            StartCoroutine(textDelay(1));
            
        }
    }

    private IEnumerator textDelay(int numero)
    {
        yield return new WaitForSeconds(numero);
        SpeedModifier();
    }
}
