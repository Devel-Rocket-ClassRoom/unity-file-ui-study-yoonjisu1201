using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CharacterTableTest2 : MonoBehaviour
{
    public Image icon;
    public LocalizationText textName;
    public LocalizationText textDesc;
    public TextMeshProUGUI stat;

    private void OnEnable()
    {
        SetEmpty();
    }
    public void SetEmpty()
    {
        icon.sprite = null;
        textName.id = string.Empty;
        textDesc.id = string.Empty;
        stat.text = string.Empty;

        textName.OnChangedId();
        textDesc.OnChangedId();
    }

    public void SetItemData(string itemId)
    {
        CharacterData data = DataTableManager.CharacterTable.Get(itemId);
        SetItemData(data);
    }
    public void SetItemData(CharacterData data)
    {
        string labelAtk = DataTableManager.StringTable.Get("Label_Atk");
        string labelDef = DataTableManager.StringTable.Get("Label_Def");
        icon.sprite = data.SpriteIcon;
        textName.id = data.Name;
        textDesc.id = data.Desc;
        stat.text = $"{labelAtk}: {data.Atk}, {labelDef}: {data.Def}";

        textName.OnChangedId();
        textDesc.OnChangedId();
    }

}
