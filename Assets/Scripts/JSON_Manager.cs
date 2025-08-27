using System.IO;
using UnityEngine;

public static class JSON_Manager
{
    public static void SayHello()
    {
        Debug.Log("Hello!");
    }

    public static void SaveToJSON()
    {
        string directory = Application.persistentDataPath + "/SavedData/";
    }
    
    public static void LoadToJSON()
    {
        string directory = Application.persistentDataPath + "/SavedData/" + "responseDataBase";

        if (File.Exists(directory))
        {
            //TODO -- THIS IS THE FUN STUFF!!!
        }
        else
        {
            Debug.Log("Load Failed. No File Found");
        }
    }
}
