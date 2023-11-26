using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AddToQueueForm : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    [SerializeField] private ProductionManager productionManager;
    [SerializeField] private List<ProductionMaterial> productionMaterials = new List<ProductionMaterial>();
    [SerializeField] private TextMeshProUGUI statusText;
    public TMP_InputField inputField;
    public ProductionMaterial selectedProductionMaterial;
    public Toggle storageToggle;
    public bool isBeingStored = false;

    public int priority;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponentInChildren<TMP_Dropdown>();
        inputField = GetComponentInChildren<TMP_InputField>();
        storageToggle = GetComponentInChildren<Toggle>();
        dropdown.ClearOptions();
        selectedProductionMaterial = null;
        Populate(productionMaterials);
    }

    private void Populate(List<ProductionMaterial> options)
    {
        dropdown.AddOptions(options.ConvertAll(x => x.materialName));
    }

    public void SelectProductionMaterial(int selectedIndex)
    {
        if (selectedIndex != 0)
        {
            selectedProductionMaterial = productionMaterials[selectedIndex];
            Debug.Log("Material selected: " + selectedProductionMaterial.materialName);
        }
        else
        {
            selectedProductionMaterial = null;
            Debug.Log("Not Material selected");
        }
    }

    public void SetPriority()
    {
        priority = int.Parse(inputField.text);
        Debug.Log("Priority set to: " + priority);
    }

    public void ResetForm()
    {
        dropdown.value = 0;
        inputField.text = "";
        selectedProductionMaterial = null;
        priority = 0;
        storageToggle.isOn = false;
        isBeingStored = false;
    }

    public void CheckForNegativeValues()
    {
        int numericValue;
        bool isNumeric = int.TryParse(inputField.text, out numericValue);

        // Si el valor es numérico y es negativo lo convertimos a un valor positivo, usando `Math.Abs`
        if (isNumeric && numericValue < 0)
        {
            int abs = Math.Abs(numericValue);
            inputField.text = abs.ToString();
            priority = abs;
            Debug.Log(abs);
        }
        else if (isNumeric && numericValue >= 0)
        {
            priority = numericValue;
            Debug.Log(numericValue);
        }
    }

    public void SetStorage()
    {
        isBeingStored = storageToggle.isOn;
        Debug.Log("Is being stored: " + isBeingStored);
    }

    public void AddToQueue()
    {
        if (selectedProductionMaterial != null && priority != 0)
        {
            productionManager.AddToQueue(selectedProductionMaterial, priority, isBeingStored);
            StopAllCoroutines();
            StartCoroutine(AddToQueueSuccess());
            ResetForm();
        }
        else
        {
            Debug.Log("No se puede agregar a la cola");
            StopAllCoroutines();
            StartCoroutine(AddToQueueError());
        }
    }

    public IEnumerator AddToQueueError()
    {
        statusText.color = Color.red;

        if (selectedProductionMaterial == null && priority == 0)
        {
            statusText.text = "Selecciona un material y una prioridad";
        }
        else if (selectedProductionMaterial == null)
        {
            statusText.text = "Selecciona un material";
        }
        else if (priority == 0)
        {
            statusText.text = "Selecciona una prioridad";
        }

        yield return new WaitForSeconds(3);

        statusText.text = "Selecciona una prioridad";
    }

    public IEnumerator AddToQueueSuccess()
    {
        statusText.color = Color.green;
        statusText.text = "Agregado a la cola";
        yield return new WaitForSeconds(3);
        statusText.text = "";
    }
}