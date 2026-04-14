using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CharacterTableTest2 : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDesc;

    private void OnEnable()
    {
        SetEmpty();
    }
    public void SetEmpty()
    {
        icon.sprite = null;
        textName.text = string.Empty;
        textDesc.text = string.Empty;
    }

    public void SetItemData(string itemId)
    {
        CharacterData data = DataTableManager.CharacterTable.Get(itemId);
        SetItemData(data);
    }
    public void SetItemData(CharacterData data)
    {
        icon.sprite = data.SpriteIcon;
        textName.text = data.Name;
        textDesc.text = data.Desc;
    }

}
