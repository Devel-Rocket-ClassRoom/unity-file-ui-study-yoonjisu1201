using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public Toggle[] toggles;
    public Button cancelButton;
    public Button applyButton;

    public int selested;

    private void Awake()
    {
        toggles[0].onValueChanged.AddListener(OnEasy);
        toggles[1].onValueChanged.AddListener(OnNormal);
        toggles[2].onValueChanged.AddListener(OnHard);

        cancelButton.onClick.AddListener(OnCancel);
        applyButton.onClick.AddListener (OnApply);
    }
    public override void Open()
    {
        base.Open();

        string path = Path.Combine(Application.persistentDataPath, "difficulty.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            selested = JsonConvert.DeserializeObject<int>(json);
        }
        toggles[selested].isOn = true;
    }
    public override void Close()
    {
        base.Close();
    }

    public void OnEasy(bool active)
    {
        if (active)
        {
            selested = 0;
        }
    }
    public void OnNormal(bool active)
    {
        if (active)
        {
            selested = 1;
        }
    }
    public void OnHard(bool active)
    {
        if (active)
        {
            selested = 2;
        }
    }
    public void OnCancel()
    {
        windowManager.Open(0);
    }
    public void OnApply()
    {
        string path = Path.Combine(Application.persistentDataPath, "difficulty.json");
        string json = JsonConvert.SerializeObject(selested);
        File.WriteAllText(path, json);
        windowManager.Open(0);
    }

}
