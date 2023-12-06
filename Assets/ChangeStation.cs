using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStation : MonoBehaviour
{
    [SerializeField] private List<CameraManager> cameraManagers = new List<CameraManager>();
    [SerializeField] private List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    [SerializeField] private List<ToggleWindow> buttonBoxes = new List<ToggleWindow>();


    public void ChangeStationTo(int index)
    {
        HideStationButtonBoxes();
        DisbleCameras();
        switch (index - 1)
        {
            case 0:
                cameraManagers[0].SwtichToDefaultCamera();
                EnableStationButtons(0);
                break;
            case 1:
                cameraManagers[1].SwtichToDefaultCamera();
                EnableStationButtons(1);
                break;
            case 2:
                cameraManagers[2].SwtichToDefaultCamera();
                EnableStationButtons(2);
                break;
            default:
                Debug.Log("Opcion no valida");
                break;
        }
    }

    public void DisbleCameras()
    {
        foreach (CameraManager cameraManager in cameraManagers)
        {
            cameraManager.DisableAllCameras();
        }
    }

    private void EnableStationButtons(int index)
    {
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        canvasGroups[index].alpha = 1;
        canvasGroups[index].interactable = true;
        canvasGroups[index].blocksRaycasts = true;
    }

    private void HideStationButtonBoxes()
    {
        if (buttonBoxes[1] != null)
        {
            foreach (var buttonBox in buttonBoxes)
            {
                buttonBox.DisableWindow();
            }
        }
        else
        {
            Debug.LogWarning("FALTA ASIGNAR EL TOGGLE WINDOW DE LA ESTACION 2");
            buttonBoxes[0].DisableWindow();
            buttonBoxes[2].DisableWindow();
        }
    }
}