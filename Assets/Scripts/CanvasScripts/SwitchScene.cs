using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] private string escena;

    //Cambiar de escena mediante el string de la escena en cuestion
    public void CambiarEscena()
    {
        SceneManager.LoadScene(escena, LoadSceneMode.Single);
    }

    //Para salir de la aplicacion
    public void Salir()
    {
        Debug.Log("Saliendo...");//Solo funciona en builds
        Application.Quit();
    }
}
