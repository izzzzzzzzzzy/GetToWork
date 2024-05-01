using System.Collections.Generic;
using UnityEngine;

public static class SaveDataManager
{

    public static void SaveJsonData(IEnumerable<ISaveable> a_Saveables, string name)
    {
        SaveData sd = new();
        foreach (var saveable in a_Saveables)
        {
            saveable.PopulateSaveData(sd);
        }

        if (FileManager.WriteToFile(name, sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    public static void LoadJsonData(IEnumerable<ISaveable> a_Saveables, string name)
    {
        if (FileManager.LoadFromFile(name, out var json))
        {
            SaveData sd = new();
            sd.LoadFromJson(json);

            foreach (var saveable in a_Saveables)
            {
                saveable.LoadFromSaveData(sd);
            }

            Debug.Log("Load complete");
        }
    }
}
