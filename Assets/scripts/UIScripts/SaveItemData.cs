using UnityEngine;
using System;
using Newtonsoft.Json;

[Serializable]
public class SaveItemData
{
    //Guid : 아이템의 고유한 시리얼번호
    public Guid instanceId {  get; set; }

    [JsonConverter(typeof(ItemDataConverter))]
    public ItemData ItemData {  get; set; }
    public DateTime creationTime {  get; set; }
    public static SaveItemData GetRandomItem()
    {
        SaveItemData newItem = new SaveItemData();
        newItem.ItemData = DataTableManager.ItemTable.GetRandom();
        return newItem;
    }

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTime = DateTime.Now;
    }
}
