using System;
using TMPro;
using UnityEngine;


public class UiCharInventory : MonoBehaviour
{
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;
    public UiCharSlotList uiCharSlotList;

    private void OnEnable()
    {
        OnLoad();
        OnChangeSorting(sorting.value);
        OnChangeFiltering(filtering.value);
    }

    public void OnChangeSorting(int index)
    {
        uiCharSlotList.Sorting = (UiCharSlotList.SortingOptions)index;
    }
    public void OnChangeFiltering(int index)
    {
        uiCharSlotList.Filtering = (UiCharSlotList.FilteringOptions)index;
    }
    public void OnSave()
    {

        SaveLoadManager.Data.CharList = uiCharSlotList.GetSaveCharDataList();
        SaveLoadManager.Data.CharSorting = (UiCharSlotList.SortingOptions)sorting.value;
        SaveLoadManager.Data.CharFiltering = (UiCharSlotList.FilteringOptions)filtering.value;
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        SaveLoadManager.Load();
        sorting.value = (int)SaveLoadManager.Data.CharSorting;
        filtering.value = (int)SaveLoadManager.Data.CharFiltering;
        uiCharSlotList.SetSaveCharDataList(SaveLoadManager.Data.CharList);
    }
    public void OnCreateChar()
    {
        uiCharSlotList.AddRandomChar();
    }
    public void OnRemoveChar()
    {
        uiCharSlotList.RemoveChar();
    }


}
