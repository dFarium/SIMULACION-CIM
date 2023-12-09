using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ToggleWindowCanvasGroup : MonoBehaviour
{
    [SerializeField] private GameObject backgroundPanel;
    [SerializeField] private CanvasGroup addForm;
    [SerializeField] private CanvasGroup removeForm;
    private bool isAddFormActive;
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OpenRemoveItem()
    {
        //Si esta activo, no desactivar, solo cambiar el contenido
        if (canvasGroup.alpha == 1 && isAddFormActive)
        {
            SwitchWindowForm(false);
        }
        else
        {
            ToggleWindow();
            SwitchWindowForm(false);
        }
    }

    public void OpenAddItem()
    {
        if (canvasGroup.alpha == 1 && !isAddFormActive)
        {
            SwitchWindowForm(true);
        }
        else
        {
            ToggleWindow();
            SwitchWindowForm(true);
        }
    }

    public void SwitchWindowForm(bool isAddForm)
    {
        //Mostrar addform si es true, mostrar removeform si es false
        if (isAddForm)
        {
            //Ocultar RemoveForm y mostrar AddForm
            addForm.alpha = 1;
            addForm.interactable = true;
            addForm.blocksRaycasts = true;
            isAddFormActive = true;

            removeForm.alpha = 0;
            removeForm.interactable = false;
            removeForm.blocksRaycasts = false;
        }
        else
        {
            //Ocultar AddForm y mostrar RemoveForm
            addForm.alpha = 0;
            addForm.interactable = false;
            addForm.blocksRaycasts = false;
            isAddFormActive = false;

            removeForm.alpha = 1;
            removeForm.interactable = true;
            removeForm.blocksRaycasts = true;
        }
    }

    private void ToggleWindow()
    {
        if (canvasGroup.alpha == 1)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            backgroundPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}