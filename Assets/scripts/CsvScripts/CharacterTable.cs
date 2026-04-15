using System.Collections.Generic;
using UnityEngine;
//1. csv파일 (ID / 이름 / 설명 / 공격력 ... / 아이콘)
//2. DataTable 상속  
//3. DataTableManager 등록
//4. 테스트 패널

public class CharacterData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Jop { get; set; }
    public string Desc { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public string Icon { get; set; }

    public Sprite SpriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");

    public override string ToString()
    {
        return $"{Id} / {Name} / {Jop} / {Desc} / {Atk} / {Def} / {Icon}";
    }
}

public class CharacterTable : DataTable
{
    private readonly Dictionary<string, CharacterData> table =
        new Dictionary<string, CharacterData>();


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
}
