using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ItemIds
{
    Item1,
    Item2,
    Item3,
    Item4,
}
public class ItemButton : MonoBehaviour
{
    public string id;
    public Image itemImage;
    public TextMeshProUGUI itemNameText;
    public static readonly string[] itemIds =
    {
        "Item1",
        "Item2",
        "Item3",
        "Item4",
    };

    public void UpdateSlot()
    {
        ItemData data = DataTableManager.ItemTable.Get(id);
        if (data != null)
        {
            //이미지 변경
            itemImage.sprite = data.SpriteIcon;

            //텍스트 변경
            itemNameText.text = data.StringName;
        }
    }
}
