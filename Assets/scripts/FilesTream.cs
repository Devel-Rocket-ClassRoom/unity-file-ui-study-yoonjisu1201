using System.IO;
using UnityEngine;

public class FilesTream : MonoBehaviour
{
    private void Start()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, "SaveData");
        string filePath1 = Path.Combine(folderPath, "save1.txt");
        string filePath2 = Path.Combine(folderPath, "save2.txt");
        string filePath3 = Path.Combine(folderPath, "save3.txt");
        string content1 = "매일 복습중";
        string content2 = "주말이 너무 짧아";
        string content3 = "어려워요";

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        File.WriteAllText(filePath1, content1);
        File.WriteAllText(filePath2, content2);
        File.WriteAllText(filePath3, content3);

        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {
            Debug.Log($"파일: {Path.GetFileName(file)}");
            Debug.Log($"확장자: {Path.GetExtension(file)}");
        }
    }
}
