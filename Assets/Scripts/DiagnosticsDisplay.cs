using UnityEngine;
using UnityEngine.Profiling;
using static UnityEngine.Profiling.Profiler;

public class DiagnosticsDisplay : MonoBehaviour
{
    private GUIStyle style;
    private float deltaTime = 0.0f;

    // Singleton instance
    private static DiagnosticsDisplay instance;

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        style = new GUIStyle();
        style.fontSize = 50;
        style.normal.textColor = Color.magenta;
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        // FPS
        GUI.Label(new Rect(10, 10, w, h * 2 / 100), "FPS: " + Mathf.Round(1.0f / deltaTime), style);

        // Tiempo de CPU
        GUI.Label(new Rect(10, 50, w, h * 2 / 100), "CPU: " + Mathf.Round((deltaTime * 1000.0f) * 100.0f) / 100.0f + " ms", style);

        // Uso de memoria
        GUI.Label(new Rect(10, 90, w, h * 2 / 100), "Memoria: " + Mathf.Round((Profiler.GetTotalAllocatedMemoryLong() / (1024.0f * 1024.0f)) * 100.0f) / 100.0f + " MB", style);
    }
}