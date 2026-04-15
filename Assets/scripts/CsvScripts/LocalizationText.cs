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
    public int charAtk;
    public int charDef;
    public TextMeshProUGUI text;
    public CharacterData characterData = new CharacterData();

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
    public void OnChangedId()
    {
        if (id == "Label")
        {
            string AtkLavel = DataTableManager.StringTable.Get("Label_Atk");
            string DefLavel = DataTableManager.StringTable.Get("Label_Def");
            if (characterData != null)
            {
                text.text = $"{AtkLavel}: {charAtk},{DefLavel}: {charDef} ";
            }
        }
        else
        {
            text.text = DataTableManager.StringTable.Get(id);
        }
    }

    private void OnChangedLanguage()
    {
        if (id == "Label")
        {
            string AtkLavel = DataTableManager.StringTable.Get("Label_Atk");
            string DefLavel = DataTableManager.StringTable.Get("Label_Def");

                text.text = $"{AtkLavel}: {charAtk},{DefLavel}: {charDef} ";

        }
        else
        {
            text.text = DataTableManager.StringTable.Get(id);
        }
    }


#if UNITY_EDITOR
    private void OnChangedLanguage(Languages lang)
    {
        var stringTable = DataTableManager.GetStringTable(lang);
        text.text = stringTable.Get(id);
    }
    [ContextMenu("ChangeLanguage")]
    private void ChangeLanguage()
    {
        // 씬에 존재하는 모든 LocalizationText_Answer 컴포넌트를 배열로 가져옴
        // FindObjectsSortMode의 열거형을 무조건 넣어줘야함. None은 정렬하지 않고 가져와서 성능적으로 유리함
        var allText = Object.FindObjectsByType<LocalizationText>(FindObjectsSortMode.None);

        foreach (var text in allText)
        {
            text.editorLang = this.editorLang;

            // 기존에는 Inspector의 값을 에디터에서 변경하면 자동으로 실행되는 코드지만, Inspector 값을 코드로 변경하면 OnValidate()가 호출되지 않아서 따로 호출
            text.OnChangedLanguage(editorLang);

            // 위의 코드로 scene에 있는 오브젝트들의 Inspector 값이 변경되지만 영구적인 저장이 안됨
            // 해당 오브젝트에 변경이 있음을 UnityEditor에게 알려서 Ctrl + S로 저장해야되는 내용임을 알려줌
            UnityEditor.EditorUtility.SetDirty(text);
        }
    }
#endif
}
