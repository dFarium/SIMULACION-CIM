using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownOptions : MonoBehaviour
{
    private TMP_Dropdown dropdown;
    [SerializeField]private List<ProductionMaterial> productionMaterials = new List<ProductionMaterial>();
    public ProductionMaterial selectedProductionMaterial;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.ClearOptions();
        selectedProductionMaterial = productionMaterials[0];
        Populate(productionMaterials);
    }

    private void Populate(List<ProductionMaterial> options)
    {
        dropdown.AddOptions(options.ConvertAll(x => x.materialName));
    }

    public void SelectProductionMaterial(int selectedIndex)
    {
        selectedProductionMaterial = productionMaterials[selectedIndex];
        Debug.Log("Material selected: " + selectedProductionMaterial.materialName);
    }
}
