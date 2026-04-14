using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemTableTest1 : MonoBehaviour
{
    public string itemId;
    public Image icon;
    public LocalizationText textName;
    public ItemTableTest2 ItemTableTest2;

    private void OnEnable()
    {
        OnChangeItemId();
    }
    private void OnValidate()
    {
        OnChangeItemId();
    }
    public void OnChangeItemId()
    {
        ItemData data = DataTableManager.ItemTable.Get(itemId);
        if (data != null)
        {
            //이미지 변경
            icon.sprite = data.SpriteIcon;

            //텍스트 변경
            textName.id = data.Name;
        }
    }
    public void OnClick()
    {
        ItemTableTest2.SetItemData(itemId);
    }

}
