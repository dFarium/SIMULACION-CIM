using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStation : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private List<CanvasGroup> canvasGroups = new List<CanvasGroup>();
    [SerializeField] private List<ToggleWindow> buttonBoxes = new List<ToggleWindow>();


    public void ChangeStationTo(int index)
    {
        HideStationButtonBoxes();
        int parsedIndex = index - 1;
        switch (parsedIndex)
        {
            case 0:
                Debug.Log(parsedIndex);
                cameraManager.SwitchToDefaultStationCameraFromIndex(parsedIndex);
                cameraManager.currentStationIndex = 0;
                EnableStationButtons(0);
                break;
            case 1:
                Debug.Log(parsedIndex);
                cameraManager.SwitchToDefaultStationCameraFromIndex(parsedIndex);
                cameraManager.currentStationIndex = 1;
                EnableStationButtons(1);
                break;
            case 2:
                Debug.Log(parsedIndex);
                cameraManager.SwitchToDefaultStationCameraFromIndex(parsedIndex);
                cameraManager.currentStationIndex = 2;
                EnableStationButtons(2);
                break;
            default:
                cameraManager.SwitchToSceneDefaultCamera();
                Debug.Log("Opcion no valida");
                break;
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