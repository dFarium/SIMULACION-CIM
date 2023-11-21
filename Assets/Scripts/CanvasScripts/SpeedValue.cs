using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SpeedValue : MonoBehaviour
{
    //Indica el valor de velocidad de movimiento del robot
    [SerializeField] private TextMeshProUGUI speedTextValue;
    //Mensaje por defecto de la botonera cuando no hace nada
    [SerializeField] private TextMeshProUGUI controlMainText;
    //Texto de apoyo para ingresar velocidad
    [SerializeField] private TextMeshProUGUI auxiliarText;
    [SerializeField] private TextMeshProUGUI numericText;
    
    private string defaultControlText = "Esperando Accion";
    
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
        auxiliarText.text = "enter speed";
        numericText.text = "_";
        
        //intercambia los textos en la botonera
        controlMainText.gameObject.SetActive(false);
        numericText.gameObject.SetActive(true);
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

    // Permite actualizar el string (o texto) que muesrta en la botonera el valor actual de la speed
    public void ChangeSpeed(string number)
    {
        if (numericText.text == "_")
        {
            numericText.text = number;
        }
        else
        {
            if(numericText.text.Length < 3) numericText.text = numericText.text + number;
        }
        
    }

    // Deshace los cambios en la variable speedText y ejecuta "Confirm" 
     
    public void Cancel()
    {
        numericText.text = speedTextValue.text;
        Confirm();
    }
    
    /* Verifica que el valor de speed este dentro del limite 1~100
     * Activa los botones desactivados y esconde los botones numericos
     * En caso de error, muestra mensaje en botonera
     */
    public void Confirm()
    {
        //comprueba que el valor esta dentro del rango
        int.TryParse(numericText.text, out int flag);
        if (flag>0 && flag<101)
        {
            speedTextValue.text = numericText.text;
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
            controlMainText.text = "SPEED IN "+ speedTextValue.text;
            StartCoroutine(confirmDelay(1));
            
            controlMainText.gameObject.SetActive(true);
            numericText.gameObject.SetActive(false);
            auxiliarText.gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log("error speed");
            controlMainText.text = "ERROR SPEED INVALIDA";
            controlMainText.gameObject.SetActive(true);
            numericText.gameObject.SetActive(false);
            auxiliarText.gameObject.SetActive(false);
            StartCoroutine(errorDelay(1));
            
        }
    }

    private IEnumerator errorDelay(int numero)
    {
        yield return new WaitForSeconds(numero);
        SpeedModifier();
    }
    
    private IEnumerator confirmDelay(int numero)
    {
        yield return new WaitForSeconds(numero);
        controlMainText.text = defaultControlText;
    }
}
