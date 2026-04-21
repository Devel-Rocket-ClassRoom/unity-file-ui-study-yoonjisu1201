using UnityEngine;
using TMPro;

public class UiPanelInventory : MonoBehaviour
{
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public UiInvenSlotList uiInvenSlotList;
    public UiItemInfo uiItemInfo;

    private void OnEnable()
    {
        OnLoad();
        OnChangeFiltering(filtering.value);
        OnChangeSorting(sorting.value);
    }
    

    public void OnChangeSorting(int index)
    {
        uiInvenSlotList.Sorting = (UiInvenSlotList.SortingOptions)index;
    }

    public void OnChangeFiltering(int index)
    {
        uiInvenSlotList.Filtering = (UiInvenSlotList.FilteringOptions)index;
    }

    public void OnSave()
    {
        SaveLoadManager.Data.ItemList = uiInvenSlotList.GetSaveItemDataList();
        SaveLoadManager.Data.ItemSorting = (UiInvenSlotList.SortingOptions)sorting.value;
        SaveLoadManager.Data.ItemFiltering = (UiInvenSlotList.FilteringOptions)filtering.value;
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        SaveLoadManager.Load();
        sorting.value = (int)SaveLoadManager.Data.ItemSorting;
        filtering.value = (int)SaveLoadManager.Data.ItemFiltering;
        uiInvenSlotList.SetSaveItemDataList(SaveLoadManager.Data.ItemList);
    }

    public void OnCreateItem()
    {
        uiInvenSlotList.AddRandomItem();
    }

    public void OnRemoveItem()
    {
        uiInvenSlotList.RemoveItem();
    }
    
}