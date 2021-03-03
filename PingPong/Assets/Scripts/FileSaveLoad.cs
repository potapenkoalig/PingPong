using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FileSaveLoad : MonoBehaviour
{
    public static int bestScoreTop  = 0;
    public static int bestScoreDown = 0;
    public static Color ballColor = Color.white;

    void Awake()
    {
        LoadFile();
        SaveFile();
    }

    public static void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        GameData data = new GameData(bestScoreTop, bestScoreDown, ballColor);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public static void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        bestScoreTop  = data.bestScoreTop;
        bestScoreDown = data.bestScoreDown;
        ballColor.r   = data.ball_color_r;
        ballColor.g   = data.ball_color_g;
        ballColor.b   = data.ball_color_b;
    }
}
