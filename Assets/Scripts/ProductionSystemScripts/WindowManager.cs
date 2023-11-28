using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private List<Canvas> windowsList = new List<Canvas>();

    public void PlaceWindowOnTop(Canvas canvasOnTop)
    {
        foreach (Canvas canvas in windowsList)
        {
            if (canvas == canvasOnTop)
            {
                canvas.sortingOrder = 45;
            }
            else
            {
                canvas.sortingOrder = 30;
            }
        }
    }
}
