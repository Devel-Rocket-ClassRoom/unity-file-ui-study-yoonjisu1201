using System.IO;
using UnityEngine;

public class FilesTream1 : MonoBehaviour
{
    private void Start()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, "SaveData1");
        string filePath1 = Path.Combine(folderPath, "save1.txt");
        string filePath2 = Path.Combine(folderPath, "save2.txt");
        string filePath3 = Path.Combine(folderPath, "save3.txt");
        string filePath4 = Path.Combine(folderPath, "save1_backup.txt");
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
        Debug.Log("=== 세이브 파일 목록 ===");

        string[] files = Directory.GetFiles(folderPath);
        foreach (string file in files)
        {
            Debug.Log($"파일: {Path.GetFileName(file)} ({Path.GetExtension(file)})");
        }

        File.Copy(filePath1, filePath4, true);
        if (File.Exists(filePath4))
        {
            Debug.Log("save1.txt → save1_backup.txt 복사 완료");
        }

        File.Delete(filePath3);
        if (!File.Exists(filePath3))
        {
            Debug.Log("save3.txt 삭제 완료");
        }

        Debug.Log("=== 작업 후 파일 목록 ===");
        files = Directory.GetFiles(folderPath);
        foreach (var file in files)
        {
            Debug.Log($"파일: {Path.GetFileName(file)} ({Path.GetExtension(file)})");
        }
    }
}
