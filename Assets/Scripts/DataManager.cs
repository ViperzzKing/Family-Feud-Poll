using System;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //TODO -- Update this list everytime your user answers relevant question
    public List<Question> myQuestions;
    //TODO -- Use these varibles in the assignment
    public Question currentQuestion;
    public int index = 0;

    private void Start()
    {
        LoadGame();
    }

    /// <summary>
    /// Creates a SavedData file and give it all the questions in 'myQuestions'
    /// Encrypt that into a JSON file with the JSON_Manager
    /// </summary>
    [ContextMenu("Save Game")]
    public void SaveGame()
    {
        Debug.Log("Saving Game...");
        SavedData savedData = new SavedData();

        savedData.savedQuestions = myQuestions;  
        
        JSON_Manager.SaveToJSON(savedData);
    }

    /// <summary>
    /// Use the JSON_Manager to retreive the questions stored away
    /// Push them into 'myQuestions' list
    /// If the load fails, save the game instead to make a new file
    /// </summary>
    [ContextMenu("Load Game")]
    public void LoadGame()
    {
        Debug.Log("Loading Game...");
        SavedData loadedData = JSON_Manager.LoadFromJSON();
        
        if(loadedData != null)
            myQuestions = loadedData.savedQuestions;
        else
            SaveGame();
    }
}

[Serializable]

// Can be a new script
public class Question // Stores the Questions & Responses
{
    public string question;
    public List<string> responses;
}
