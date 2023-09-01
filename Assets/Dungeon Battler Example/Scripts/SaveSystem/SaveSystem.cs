using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;
    public SaveData activeSave;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            // load from the save system
            Load();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void Save()
    {
        Debug.Log("Saving Data");
        string dataPath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/Dungeon.save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();
    }
    public void Load()
    {
        Debug.Log("Loading Data");
        string dataPath = Application.persistentDataPath;
        if (File.Exists(dataPath + "/Dungeon.save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/Dungeon.save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
        }
        else
        {
            Debug.LogWarning("No save data to load");
        }
    }
}