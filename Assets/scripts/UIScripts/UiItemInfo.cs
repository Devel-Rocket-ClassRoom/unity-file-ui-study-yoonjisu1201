using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiItemInfo : MonoBehaviour
{
    //string.Format( "{0}: {1}" , 첫번째 인자  ,  두번째 인자  ) 유연성
    public static readonly string FormatCommon = "{0}: {1}";
    public Image imageIcon;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDesxription;
    public TextMeshProUGUI textType;
    public TextMeshProUGUI textValuye;
    public TextMeshProUGUI textCost;
    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string .Empty;
        textDesxription.text = string .Empty;
        textType.text = string .Empty;
        textValuye.text = string .Empty;
        textCost.text = string .Empty;
    }
    public void SetSaveItemData(SaveItemData saveItemData)
    {
        ItemData data = saveItemData.ItemData;

        imageIcon.sprite = data.SpriteIcon;
        textName.text = 
            string.Format(FormatCommon, DataTableManager.StringTable.Get("NAME"), data.StringName);
        textDesxription.text =
            string.Format(FormatCommon, DataTableManager.StringTable.Get("DESC"), data.StringDesc);
        string id = data.Type.ToString().ToUpper();
        textType.text =
            string.Format(FormatCommon,
            DataTableManager.StringTable.Get("TYPE"),
            DataTableManager.StringTable.Get(id));
        textValuye.text =
            string.Format(FormatCommon, DataTableManager.StringTable.Get("VALUE"), data.Value);
        textCost.text =
            string.Format(FormatCommon, DataTableManager.StringTable.Get("COST"), data.Cost);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetEmpty();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetSaveItemData(SaveItemData.GetRandomItem());
        }
    }
}
