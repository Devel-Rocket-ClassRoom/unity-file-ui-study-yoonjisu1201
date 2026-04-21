using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiCharSlotList : MonoBehaviour
{
    public UiCharSlot prefab;
    public ScrollRect scrollRect;

    private List<UiCharSlot> uiSlotList = new List<UiCharSlot>();
    private List<SaveCharData> saveCharDataList = new List<SaveCharData>();

    public void SetSaveCharDataList(List<SaveCharData> data)
    {
        saveCharDataList = data.ToList();
    }
    public List<SaveCharData> GetSaveCharDataList()
    {
        return saveCharDataList;
    }

    private void UpdateCharSlots()
    {
        if (uiSlotList.Count < saveCharDataList.Count)
        {
            for (int i = uiSlotList.Count; i < saveCharDataList.Count; i++)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);

                //캐릭터 슬릇 눌렀을때 인포랑 연결되는 코드


                uiSlotList.Add(newSlot);
            }

            for (int i = 0; i < uiSlotList.Count; i++)
            {
                if (i < saveCharDataList.Count)
                {
                    uiSlotList[i].gameObject.SetActive(true);
                    uiSlotList[i].SetCharacter(saveCharDataList[i]);
                }
                else
                {
                    uiSlotList[i].gameObject.SetActive(false);
                    uiSlotList[i].SetEmpty();
                }
            }
        }
    }

    public void AddRandomChar()
    {
        saveCharDataList.Add(SaveCharData.GetRandomChar());
        UpdateCharSlots();
    }



}
