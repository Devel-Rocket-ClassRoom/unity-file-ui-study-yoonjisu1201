using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CharacterTableTest2 : MonoBehaviour
{
    public Image icon;
    public LocalizationText textName;
    public LocalizationText textDesc;
    public LocalizationText stat;

    private void OnEnable()
    {
        SetEmpty();
    }
    public void SetEmpty()
    {
        icon.sprite = null;
        textName.id = string.Empty;
        textDesc.id = string.Empty;
        stat.id = string.Empty;
        stat.charAtk = 0;
        stat.charDef = 0;

        textName.OnChangedId();
        textDesc.OnChangedId();
        stat.OnChangedId();
    }

    public void SetCharacterData(string characterId)
    {
        CharacterData data = DataTableManager.CharacterTable.Get(characterId);
        SetCharacterData(data);
    }
    public void SetCharacterData(CharacterData data)
    {
        icon.sprite = data.SpriteIcon;
        textName.id = data.Name;
        textDesc.id = data.Desc;
        stat.id = "Label";
        stat.charAtk = data.Atk;
        stat.charDef = data.Def;

        textName.OnChangedId();
        textDesc.OnChangedId();
        stat.OnChangedId();
    }

}
