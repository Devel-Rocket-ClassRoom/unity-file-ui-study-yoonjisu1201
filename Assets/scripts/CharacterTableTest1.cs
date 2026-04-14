using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CharacterTableTest1 : MonoBehaviour
{
    public string characterId;
    public Image icon;
    public TextMeshProUGUI textName;
    public CharacterTableTest2 CharacterTableTest2;

    private void OnEnable()
    {
        OnChangeChracterId();
    }
    private void OnValidate()
    {
        OnChangeChracterId();
    }
    public void OnChangeChracterId()
    {
        CharacterData data = DataTableManager.CharacterTable.Get(characterId);
        if (data != null)
        {
            //이미지 변경
            icon.sprite = data.SpriteIcon;

            //텍스트 변경
            textName.text = data.Name;
        }
    }
    public void OnClick()
    {
        CharacterTableTest2.SetItemData(characterId);
    }
}
