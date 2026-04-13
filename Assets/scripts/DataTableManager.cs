using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Icons;

public static class DataTableManager
{
    private static readonly Dictionary<string, DataTable> tables =
        new Dictionary<string, DataTable>();


    //현재 설정된 언어에 해당하는 StringTable을 반환하는 프로퍼티
    public static StringTable StringTable => Get<StringTable>(DataTableIds.String); 

#if UNITY_EDITOR
    public static StringTable GetStringTable(Languages lang)
    {
        return Get<StringTable>(DataTableIds.StringTableIds[(int)lang]);
    }
#endif

    static DataTableManager()
    {
        Init();
    }

    private static void Init()
    {
        //런타임 실행 시 현재 언어에 맞는 StringTable만 로드
#if !UNITY_EDITOR
        var stringTable = new StringTable();
        stringTable.Load(DataTableIds.String);
        tables.Add(DataTableIds.String, stringTable);
#else
        //에디터에서 실행 시 모든 언어의 StringTable을 로드
        foreach (var id in DataTableIds.StringTableIds)
        {
            var stringTable = new StringTable();
            stringTable.Load(id);
            tables.Add(id, stringTable);
        }
#endif
    }

    public static void ChangeLanguage(Languages lang)
    {
        //바꿀 언어의 파일 이름
        string newId = DataTableIds.StringTableIds[(int)lang];

        if (tables.ContainsKey(newId))
        {
            return;
        }

        string oldId = string.Empty;
        foreach (var id in DataTableIds.StringTableIds)
        {
            if (tables.ContainsKey(id))
            {
                oldId = id;
                break;
            }
        }
        var stringTable = tables[oldId];
        stringTable.Load(newId);
        tables.Remove(oldId);
        tables.Add(newId, stringTable);
    }
    public static T Get<T>(string id) where T : DataTable
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError("테이블 없음");
            return null;
        }
        return tables[id] as T;
    }
}