using UnityEngine;
using UnityEngine.iOS;

public class DataTableTest : MonoBehaviour
{
    public string NameStringTableKR = "StringTableKr"; 
    public string NameStringTableEN = "StringTableEn";
    public string NameStringTableJP = "StringTableJp";

    public void OnClickStringTableKR()
    {
        StringTable stringTable = new StringTable();
        stringTable.Load(NameStringTableKR);
        Debug.Log(stringTable.Get("YOU DIE"));
    }
    public void OnClickStringTableEN()
    {
        StringTable stringTable = new StringTable();
        stringTable.Load(NameStringTableEN);
        Debug.Log(stringTable.Get("YOU DIE"));
    }
    public void OnClickStringTableJP()
    {
        StringTable stringTable = new StringTable();
        stringTable.Load(NameStringTableJP);
        Debug.Log(stringTable.Get("YOU DIE"));
    }
}
