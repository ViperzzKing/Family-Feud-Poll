using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class JSON_Manager
{
    
    /// <summary>
    /// We use this JSON Encryption algorithim to take a object (SavedData) and push it into a Text/JSON file
    /// CTRL-V in file browser to see where its saved
    /// </summary>
    /// <param name="data"></param>
    public static void SaveToJSON(SavedData data)
    {
        string directory = Application.persistentDataPath + "/SavedData/";

        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        
        string jsonEncryption = JsonUtility.ToJson(data, true);
        
        File.WriteAllText(directory + "responseDataBase.json", jsonEncryption);
        GUIUtility.systemCopyBuffer = directory; // CTRL-C
    }
    
    /// <summary>
    /// We do this so we can turn a Text/JSON file into a object(SavedData) which will be returned
    /// Returns "Null" if it cant find a file
    /// </summary>
    /// <returns></returns>
    public static SavedData LoadFromJSON()
    {
        string directory = Application.persistentDataPath + "/SavedData/" + "responseDataBase.json";

        if (File.Exists(directory))
        {
            string json = File.ReadAllText(directory);
            return JsonUtility.FromJson<SavedData>(json);
        }
        else
        {
            Debug.Log("Load Failed. No File Found");
            return null;
        }
    }
}

[Serializable] // Show in Inspector

// This class can be its own script
public class SavedData // This way we can collect information you can save when prompted
{
    // Can save any varible here were saving a list
    public List<Question> savedQuestions;
}
