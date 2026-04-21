using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiCharSlotList : MonoBehaviour
{
    public enum SortingOptions 
    {
        Default,
        GradeDesc,
        AtkDesc,
    }
    public enum FilteringOptions
    {
        All,       
        SSR_Only,  
        SR_Over    // SR 등급 이상 (SR, SSR)
    }

    public readonly System.Comparison<SaveCharData>[] comparisons =
    {
        (lhs, rhs) => lhs.creationTime.CompareTo(rhs.creationTime),
        (lhs, rhs) => rhs.characterData.Grade.CompareTo(lhs.characterData.Grade),
        (lhs, rhs) => rhs.characterData.Atk.CompareTo(lhs.characterData.Atk),

    };
    public readonly System.Func<SaveCharData, bool>[] filterings =
    {
        (x) => true,
        (x) => x.characterData.Grade == CharacterGrade.SSR,
        (x) => x.characterData.Grade >= CharacterGrade.SR,
    };

    public UiCharSlot prefab;
    public ScrollRect scrollRect;

    private List<UiCharSlot> uiSlotList = new List<UiCharSlot>();
    private List<SaveCharData> saveCharDataList = new List<SaveCharData>();
    private int selectedSlotIndex = -1;

    public UnityEvent onUpdateSlots;
    public UnityEvent<SaveCharData> onSelectSlot;

    private SortingOptions sorting = SortingOptions.Default;
    private FilteringOptions filtering = FilteringOptions.All;

    public SortingOptions Sorting
    {
        get => sorting;
        set
        {
            if (sorting != value)
            {
                sorting = value;
                UpdateCharSlots();
            }
        }
    }
    public FilteringOptions Filtering
    {
        get => filtering;
        set
        {
            if (filtering != value)
            {
                filtering = value;
                UpdateCharSlots();
            }
        }
    }

    public void SetSaveCharDataList(List<SaveCharData> data)
    {
        saveCharDataList = data.ToList();
        UpdateCharSlots();
    }
    public List<SaveCharData> GetSaveCharDataList()
    {
        return saveCharDataList;
    }

    private void UpdateCharSlots()
    {
        var filteredList = saveCharDataList.Where(filterings[(int)filtering]).ToList();
        filteredList.Sort(comparisons[(int)Sorting]);

        if (uiSlotList.Count < filteredList.Count)
        {
            for (int i = uiSlotList.Count; i < filteredList.Count; i++)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);

                //캐릭터 슬릇 눌렀을때 인포랑 연결되는 코드
                newSlot.button.onClick.AddListener(() =>
                {
                    selectedSlotIndex = newSlot.slotIndex;
                    onSelectSlot.Invoke(newSlot.SaveCharData);
                });

                uiSlotList.Add(newSlot);
            }
        }

        for (int i = 0; i < uiSlotList.Count; i++)
        {
            if (i < filteredList.Count)
            {
                uiSlotList[i].gameObject.SetActive(true);
                uiSlotList[i].SetCharacter(filteredList[i]);
            }
            else
            {
                uiSlotList[i].gameObject.SetActive(false);
                uiSlotList[i].SetEmpty();
            }
            selectedSlotIndex = -1;
            onUpdateSlots.Invoke();
        }

    }

    public void AddRandomChar()
    {
        saveCharDataList.Add(SaveCharData.GetRandomChar());
        UpdateCharSlots();
    }
    public void RemoveChar()
    {
        if (selectedSlotIndex == -1)
        {
            return;
        }

        saveCharDataList.Remove(uiSlotList[selectedSlotIndex].SaveCharData);
        UpdateCharSlots();
    }



}
