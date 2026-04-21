using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiCharSlot : MonoBehaviour
{
    public int slotIndex = -1;
    public Image imageIcon;
    public TextMeshProUGUI TextName;

    public SaveCharData SaveCharData;

    public void SetEmpty()
    {
        imageIcon.sprite = null;
        TextName.text = string.Empty;
    }

    public void SetCharacter(SaveCharData data)
    {
        imageIcon.sprite = data.characterData.SpriteIcon;
        TextName.text = data.characterData.Name;
    }
}
