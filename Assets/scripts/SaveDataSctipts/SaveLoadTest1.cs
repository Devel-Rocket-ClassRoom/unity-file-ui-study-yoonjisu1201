using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using SaveDataVC = SaveDataV1; //네이밍 에일리어스 (별명같은거임)


public class SaveLoadTest1 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (SaveLoadManager.Data == null) SaveLoadManager.Data = new SaveDataV3();
            SaveLoadManager.Data.Name = "TEST1234";
            SaveLoadManager.Data.Gold = 4321;

            if (SaveLoadManager.Save()) Debug.Log("저장 성공!");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (SaveLoadManager.Load())
            {
                foreach (var itemId in SaveLoadManager.Data.ItemIds)
                {
                    Debug.Log($"{itemId}");
                }
                Debug.Log(SaveLoadManager.Data.Name);
                Debug.Log(SaveLoadManager.Data.Gold);
            }
            else
            {
                Debug.Log("세이브 파일 없음");
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            List<string> itemIds = DataTableManager.ItemTable.GetItemId();
            string randonId = itemIds[Random.Range(0, itemIds.Count)];
            SaveLoadManager.Data.ItemIds.Add(randonId);
            Debug.Log($"아이디 추가: {randonId}");
        }
    }
}
