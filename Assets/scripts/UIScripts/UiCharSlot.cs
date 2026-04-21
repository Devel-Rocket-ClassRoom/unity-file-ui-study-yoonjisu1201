using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiCharSlot : MonoBehaviour
{
    public int slotIndex = -1;
    public Image imageIcon;
    public TextMeshProUGUI TextName;

    public SaveCharData SaveCharData;
    public Button button;

    public Image imageFrame;      
    public Sprite spriteSSR;      
    public Sprite spriteSR;       
    public Sprite spriteR;        
    public Sprite spriteEmpty;    
    public void SetEmpty()
    {
        imageIcon.sprite = null;
        TextName.text = string.Empty;
        if (imageFrame != null)
        {
            imageFrame.sprite = spriteEmpty;
        }
        SaveCharData = null;
    }

    public void SetCharacter(SaveCharData data)
    {
        SaveCharData = data;
        imageIcon.sprite = data.characterData.SpriteIcon;
        TextName.text = data.characterData.StringName;
        if (imageFrame != null)
        {
            switch (data.characterData.Grade)
            {
                case CharacterGrade.SSR: imageFrame.sprite = spriteSSR; break;
                case CharacterGrade.SR: imageFrame.sprite = spriteSR; break;
                case CharacterGrade.R: imageFrame.sprite = spriteR; break;
            }
        }
    }
}
