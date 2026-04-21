using Newtonsoft.Json;
using System;
using UnityEngine;

[Serializable]
public class SaveCharData 
{
    public Guid instanceId { get; set; }
    [JsonConverter(typeof(CharDataConverter))]
    public CharacterData characterData { get; set; }
    public DateTime creationTime { get; set; }
    public static SaveCharData GetRandomChar()
    {
        SaveCharData newChar = new SaveCharData();
        newChar.characterData = DataTableManager.CharacterTable.GetRandom();
        return newChar;
    }

    public SaveCharData()
    {
        creationTime = DateTime.Now;
        instanceId = Guid.NewGuid();
    }
}
