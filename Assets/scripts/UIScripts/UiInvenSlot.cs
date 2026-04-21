using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiInvenSlot : MonoBehaviour
{
    public int slotIndex = -1;
    public Image imageIcon;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textCost;
    public TextMeshProUGUI textCostValue;
    public SaveItemData SaveItemData {  get; private set; }
    public Button button;
    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string.Empty;
        textCost.text = string.Empty;
        textCostValue.text = string.Empty;
        SaveItemData = null;
    }
    public void SetItem(SaveItemData data)
    {
        SaveItemData = data;
        imageIcon.sprite = SaveItemData.ItemData.SpriteIcon;
        textName.text = SaveItemData.ItemData.StringName;
        textCost.text = DataTableManager.StringTable.Get("COST");
        textCostValue.text = SaveItemData.ItemData.Cost.ToString();
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    SetEmpty();
        //}
        //if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    var saveItemData = new SaveItemData();
        //    SaveItemData.ItemData = DataTableManager.ItemTable.Get("Item1");
        //    SetItem(saveItemData);
        //}
    }
}
