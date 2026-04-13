using UnityEngine;

public enum Languages
{
    Korean,
    English,
    Japanese,
}
public static class Variables
{
    public static System.Action OnLanguageChange;
    private static Languages language = Languages.Korean;
    private static Languages Languages
    {
        get { return language; }
        set
        {
            if (language == value) return;
            language = value;
            DataTableManager.ChangeLanguage(language);
            OnLanguageChange?.Invoke();
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
