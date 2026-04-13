using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Icons;

public enum StringId
{
    HELLO,
    BYE,
    YOUDIE,
}
public class StringTableText : MonoBehaviour
{
    public static readonly string[] StringIds =
    {
        "HELLO",
        "BYE",
        "YOU DIE"
    };

    public StringId stringId;
    public string id;
    public TextMeshProUGUI text;
    public TextMeshProUGUI buttonText;

    private void Start()
    {

        OnChangeId();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Variables.Language = Languages.Korean;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Variables.Language = Languages.English;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Variables.Language = Languages.Japanese;
        }
    }
    public void OnChangeId()
    {
        buttonText.text = StringIds[(int)stringId];
        text.text = DataTableManager.StringTable.Get(StringIds[(int)stringId]);
    }
}
