using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedMove : MonoBehaviour
{
    [SerializeField] private List<Button> selected;
    [SerializeField] private List<Button> unselected;
    
    public void ShowSelected()
    {
        foreach (Button button in unselected)
        {
            button.gameObject.SetActive(false);
        }
        foreach (Button button in selected)
        {
            button.gameObject.SetActive(true);
        }
    }
}
