using UnityEngine;

public enum Languages
{
    Korean,
    English,
    Japanese,
}

//현재 언어 설정과 관련된 변수와 이벤트를 관리하는 클래스
public static class Variables
{
    public static System.Action OnLanguageChanged;
    private static Languages language = Languages.Korean;
    public static Languages Language
    {
        get { return language; }
        set
        {
            if (language == value) return;
            language = value;
            DataTableManager.ChangeLanguage(language);
            OnLanguageChanged?.Invoke();
        }
    }
}

public static class DataTableIds
{
    public static readonly string[] StringTableIds =
    {
        "StringTableKr",
        "StringTableEn",
        "StringTableJp"
    };
    public static string String => StringTableIds[(int)Variables.Language];
}
