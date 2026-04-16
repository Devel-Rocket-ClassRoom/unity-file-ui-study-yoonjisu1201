using UnityEngine;
using SaveDataVC = SaveDataV3; //네이밍 에일리어스 (별명같은거임)
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UIElements;
public static class SaveLoadManager
{
    public enum SaveMode
    {
        Text,  //.json
        Encrypted,  // .dat
    }

    public static SaveMode Mode { get; set; } = SaveMode.Text;
    private static byte[] encrypted;
    //지금 사용하고 있는 버전??
    public static int SaveDataVersion { get; } = 3;
    private static readonly string SaveDirectory = $"{Application.persistentDataPath}/Save";
    private static readonly string[] SaveFileNames =
     {
        "SaveAuto",
        "Save1",
        "Save2",
        "Save3",
    };


    //세이브하면 여기에 저장됨
    public static SaveDataVC Data { get; set; } = new SaveDataVC();
    private static string GetSaveFilePath(int slot)
    {
        return GetSaveFilePath(slot, Mode);
    }
    public static string GetSaveFilePath(int slot, SaveMode mode)
    {
        var ext = mode == SaveMode.Text ? ".json" : ".dat";
        return Path.Combine(SaveDirectory, $"{SaveFileNames[slot]}{ext}");
    }
    private static JsonSerializerSettings settings = new JsonSerializerSettings()
    {
        Formatting = Formatting.Indented,
        TypeNameHandling = TypeNameHandling.All,
    };

    public static bool Save(int slot = 0)
    {
        return Save(slot, Mode);
    }
    public static bool Save(int slot, SaveMode mode)
    {
        if (Data == null || slot < 0 || slot >= SaveFileNames.Length)
        {
            return false;
        }
        //여기에선 예외처리 필수
        try
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            //json or 암호화
            var json = JsonConvert.SerializeObject(Data, settings);
            string path = GetSaveFilePath(0, mode);

            switch (mode)
            {
                case SaveMode.Text:
                    File.WriteAllText(path, json);
                    break;
                case SaveMode.Encrypted:
                    File.WriteAllBytes(path, CryptoUtil.Encrypt(json));
                    break;
            }
            return true;
        }
        catch
        {
            Debug.LogError("Save 예외");
            return false;
        }
    }
    public static bool Load(int slot = 0)
    {
        return Load(slot, Mode);
    }
    public static bool Load(int slot, SaveMode mode)
    {
        if (slot < 0 || slot >= SaveFileNames.Length)
        {
            return false;
        }


        string path = GetSaveFilePath(0, mode);
        if (!File.Exists(path))
        {
            return false;
        }
        try
        {
            var json = string.Empty;
            switch (mode)
            {
                case SaveMode.Text:
                    json = File.ReadAllText(path);
                    break;
                case SaveMode.Encrypted:
                    json = CryptoUtil.Decrypt(File.ReadAllBytes(path));
                    break;
            }
            var saveData = JsonConvert.DeserializeObject<SaveData>(json, settings);
            while (saveData.Version < SaveDataVersion)
            {
                Debug.Log(saveData.Version);
                saveData = saveData.VersionUp();
                Debug.Log(saveData.Version);
            }
            Data = saveData as SaveDataVC;

            return true;
        }
        catch
        {
            Debug.LogError("Save 예외");
            return false;
        }
    }
}
