using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.LowLevelPhysics2D.PhysicsLayers;

[System.Serializable]
public abstract class SaveData
{
    //세이브 데이터의 버전
    public int Version { get; protected set; }
    public abstract SaveData VersionUp();
}
[System.Serializable]
public class SaveDataV1 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public SaveDataV1()
    {
        Version = 1;
    }

    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV2();
        saveData.Name = PlayerName;
        saveData.Gold = 0;
        return saveData;

    }
}
[System.Serializable]
public class SaveDataV2 : SaveData
{
    public string Name { get; set; } = string.Empty;
    public int Gold = 0;
    public SaveDataV2()
    {
        Version = 2;
    }
    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV3();
        saveData.Name = Name;
        saveData.Gold = Gold;
        return saveData;
    }
}

[System.Serializable]
public class SaveDataV3 : SaveData
{
    public string Name { get; set; } = string.Empty;
    public int Gold = 0;
    public List<string> ItemIds = new List<string>();
    public SaveDataV3()
    {
        Version = 3;
    }
    public override SaveData VersionUp()
    {
        var saveData = new SaveDataV4();
        saveData.Name = Name;
        saveData.Gold = Gold;

        foreach (var id in ItemIds)
        {
            SaveItemData itemData = new SaveItemData();
            itemData.ItemData = DataTableManager.ItemTable.Get(id);
            saveData.ItemList.Add(itemData);
        }
        return saveData;
    }
}
[System.Serializable]
public class SaveDataV4 : SaveDataV2
{
    public List<SaveItemData> ItemList = new List<SaveItemData>();

    public SaveDataV4()
    {
        Version = 4;
    }

    public override SaveData VersionUp()
    {
        // 현재 최신 버전. 호출되면 안 되는 경로.
        throw new InvalidOperationException("SaveDataV3은 최신 버전입니다. VersionUp() 호출 대상이 아닙니다.");
    }
}

