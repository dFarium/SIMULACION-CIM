using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    //Cambiar de escena mediante el string de la escena en cuestion
    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    //Para salir de la aplicacion
    public static void ExitApplication()
    {
        Debug.Log("Saliendo..."); //Solo funciona en builds
        Application.Quit();
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}