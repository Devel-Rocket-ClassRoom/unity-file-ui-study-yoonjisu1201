using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//1. csv파일 (ID / 이름 / 설명 / 공격력 ... / 아이콘)
//2. DataTable 상속  
//3. DataTableManager 등록
//4. 테스트 패널

public enum CharacterGrade
{
    R,
    SR,
    SSR
}
public class CharacterData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Job { get; set; }
    public CharacterGrade Grade { get; set; }
    public string Desc { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public string Icon { get; set; }
    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringJob => DataTableManager.StringTable.Get(Job);
    public string StringDesc => DataTableManager.StringTable.Get(Desc);
    public Sprite SpriteIcon => Resources.Load<Sprite>($"UiIcon/{Icon}");

    public override string ToString()
    {
        return $"{Id} / {Name} / {Job} / {Grade} / {Atk} / {Def}";
    }
}

public class CharacterTable : DataTable
{
    private readonly Dictionary<string, CharacterData> table =
        new Dictionary<string, CharacterData>();

    private List<string> keyList;


    public override void Load(string filename)
    {
        table.Clear();

        string path = string.Format(FormatPath, filename);
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        List<CharacterData> list = LoadCSV<CharacterData>(textAsset.text);

        foreach (var item in list)
        {
            if (!table.ContainsKey(item.Id))
            {
                //키는 아이디, vlaue는 CharacterData 덩어리
                table.Add(item.Id, item);
            }
            else
            {
                Debug.LogError("캐릭터 아이디 중복");
            }
        }
        keyList = table.Keys.ToList();
    }
    public CharacterData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            Debug.LogError("캐릭터 아이디 없음");
            return null;
        }

        return table[id];
    }
    public CharacterData GetRandom()
    {
        return Get(keyList[Random.Range(0, keyList.Count)]);
    }
}
