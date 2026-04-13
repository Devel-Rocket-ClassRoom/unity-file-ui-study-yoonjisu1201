using TMPro;
using UnityEngine;
using static Unity.VisualScripting.Icons;

[ExecuteInEditMode]
public class LocalizationText : MonoBehaviour
{
#if UNITY_EDITOR
    public Languages editorLang;
#endif
    public string id;
    public TextMeshProUGUI text;

    private void OnEnable()
    {
        if (Application.isPlaying)
        {
            OnChangedId();
        }
#if UNITY_EDITOR
        else
        {
            OnChangedLanguage(editorLang);
            //OnChangedId();
        }
        Variables.OnLanguageChanged += OnChangedLanguage;
#endif
    }

    private void OnValidate()
    {
#if UNITY_EDITOR
        OnChangedLanguage(editorLang);
        //OnChangedId();
#else
        OnChangeLanguage();
        //OnChangedId();
#endif
    }

    private void OnDisable()
    {
        Variables.OnLanguageChanged -= OnChangedLanguage;
    }
    private void OnChangedId()
    {
        text.text = DataTableManager.StringTable.Get(id);
    }

    private void OnChangedLanguage()
    {
        text.text = DataTableManager.StringTable.Get(id);
    }

#if UNITY_EDITOR
    private void OnChangedLanguage(Languages lang)
    {
        var stringTable = DataTableManager.GetStringTable(lang);
        text.text = stringTable.Get(id);
    }
#endif
}
