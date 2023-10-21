using System.IO;
using UnityEngine;

[System.Serializable]
public class PositionData
{
    public float x;
    public float y;
    public float z;
}

public class PositionManager : MonoBehaviour
{
    private static readonly string CommonPath = Application.dataPath + "/datos guardados";
    
    public static void SavePosition(int stationNumber, int saveNumber, Vector3 position)
    {
        PositionData positionData = new PositionData
        {
            x = position.x,
            y = position.y,
            z = position.z
        };
        
        string station = "estacion" + stationNumber;
        string saveFileName = "posicion" + saveNumber + ".json";
        string filePath = CommonPath + "/" + station + "/" + saveFileName;
        Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? string.Empty);

        string jsonData = JsonUtility.ToJson(positionData,true);
        File.WriteAllText(filePath, jsonData);
    }

    public static Vector3? LoadPosition(int stationNumber, int saveNumber)
    {
        string station = "estacion" + stationNumber;
        string saveFileName = "posicion" + saveNumber + ".json";
        string filePath = CommonPath + "/" + station + "/" + saveFileName;

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            PositionData loadedPosition = JsonUtility.FromJson<PositionData>(jsonData);

            return new Vector3(loadedPosition.x, loadedPosition.y, loadedPosition.z);
        }
        //Si no encuentra el archivo
        Debug.LogWarning("El archivo de posición no existe.");
        return null;
    }
}

