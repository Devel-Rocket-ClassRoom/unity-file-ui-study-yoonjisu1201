using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiCharInfo : MonoBehaviour
{
    public static readonly string FormatCommon = "{0}: {1}";
    public Image imageIcon;
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textDesc;
    public TextMeshProUGUI textGrade;
    public TextMeshProUGUI textJob;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;
    public TextMeshProUGUI AtkValue;
    public TextMeshProUGUI DefValue;


    public void SetEmpty()
    {
        imageIcon.sprite = null;
        textName.text = string.Empty;
        textDesc.text = string.Empty;
        textGrade.text = string.Empty;
        textJob.text = string.Empty;
        AtkText.text = string.Empty;
        DefText.text = string.Empty;
        AtkValue.text = string.Empty;
        DefValue.text = string.Empty;
    }
    public void SetSaveCharData(SaveCharData saveCharData)
    {
        CharacterData data = saveCharData.characterData;

        imageIcon.sprite = data.SpriteIcon;
        textName.text = data.StringName;
        textDesc.text = data.StringDesc;
        textJob.text = data.StringJob;
        textGrade.text = data.Grade.ToString();
        AtkText.text = DataTableManager.StringTable.Get("Label_Atk");
        DefText.text = DataTableManager.StringTable.Get("Label_Def");
        AtkValue.text = data.Atk.ToString();
        DefValue.text = data.Def.ToString();
    }
}
