using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string name;
    public float debt;
    public float money;
    public int rArmHealth;
    public int lArmHealth;
    public int rLegHealth;
    public int lLegHealth;
    public int[] limbHealth;
    public int dayNum;
    public bool isEmpty;


    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json)
    {
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }
}

public interface ISaveable
{
    void PopulateSaveData(SaveData a_SaveData);
    void LoadFromSaveData(SaveData a_SaveData);
}
