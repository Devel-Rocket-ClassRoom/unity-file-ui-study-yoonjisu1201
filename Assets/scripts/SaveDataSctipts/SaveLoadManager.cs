using UnityEngine;
using SaveDataVC = SaveDataV4; //네이밍 에일리어스 (별명같은거임)
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UIElements;
    public enum SaveMode
    {
        Text,  //.json
        Encrypted,  // .dat
    }
public static class SaveLoadManager
{

    public static SaveMode Mode { get; set; } = SaveMode.Text;
    private static byte[] encrypted;
    //지금 사용하고 있는 버전??
    public static int SaveDataVersion { get; } = 4;
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
        // TypeNameHandling.All: JSON에 $type 필드를 기록/복원.
        // DeserializeObject<SaveData>로 부모 타입을 요청해도 $type을 보고 실제 타입(V1/V2/V3)으로 복원되어
        // 구버전 세이브도 VersionUp() 마이그레이션 체인을 탈 수 있다.
        TypeNameHandling = TypeNameHandling.All,
    };
    public static bool Save(int slot = 0)
    {
        if (Data == null || slot < 0 || slot >= SaveFileNames.Length)
        {
            return false;
        }

        try
        {
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            var path = GetSaveFilePath(slot);
            var json = JsonConvert.SerializeObject(Data, settings);

            if (Mode == SaveMode.Text)
            {
                File.WriteAllText(path, json);
            }
            else
            {
                File.WriteAllBytes(path, CryptoUtil.Encrypt(json));
            }

            return true;
        }
        catch
        {
            Debug.LogError("Save 예외 발생");
            return false;
        }
    }

    public static bool Load(int slot = 0)
    {
        if (slot < 0 || slot >= SaveFileNames.Length)
        {
            return false;
        }

        var path = GetSaveFilePath(slot);
        if (!File.Exists(path))
        {
            return false;
        }

        try
        {
            string json;
            if (Mode == SaveMode.Text)
            {
                json = File.ReadAllText(path);
            }
            else
            {
                json = CryptoUtil.Decrypt(File.ReadAllBytes(path));
            }

            var dataSave = JsonConvert.DeserializeObject<SaveData>(json, settings);
            // 구버전 세이브면 최신 버전까지 한 단계씩 끌어올린다.
            while (dataSave.Version < SaveDataVersion)
            {
                var prevVersion = dataSave.Version;
                dataSave = dataSave.VersionUp();
                Debug.Log($"[SaveLoad] 마이그레이션 V{prevVersion} → V{dataSave.Version}");
            }
            Data = dataSave as SaveDataVC;
            return true;
        }
        catch
        {
            Debug.LogError("Load 예외 발생");
            return false;
        }
    }
}



