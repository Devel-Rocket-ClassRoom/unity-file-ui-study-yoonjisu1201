using System.IO;
using UnityEngine;

public class FileStream2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string originalPath = Path.Combine(Application.persistentDataPath, "secret.txt");
        string encryptedPath = Path.Combine(Application.persistentDataPath, "encrypted.dat");
        string decryptedPath = Path.Combine(Application.persistentDataPath, "decrypted.txt");

        byte key = 0xAB;

        string originalMessage = "Hello Unity World";
        File.WriteAllText(originalPath, originalMessage);
        Debug.Log($"원본: {originalMessage}");

        //암호화
        using (FileStream fsRead = new FileStream(originalPath, FileMode.Open))
        using (FileStream fsWrite = new FileStream(encryptedPath, FileMode.Create))
        {
            int data;
            while((data = fsRead.ReadByte()) != -1)
            {
                byte encryptedByte = (byte)(data ^ key);
                fsWrite.WriteByte(encryptedByte);
            }
            Debug.Log($"암호화 완료 (파일크기: {fsWrite.Length} bytes)");
        }

        //복호화
        using (FileStream fsRead = new FileStream(encryptedPath, FileMode.Open))
        using (FileStream fsWrite = new FileStream(decryptedPath, FileMode.Create))
        {
            int data;
            while ((data = fsRead.ReadByte()) != -1)
            {
                byte decryptedByte = (byte)(data ^ key);
                fsWrite.WriteByte(decryptedByte);
            }
            Debug.Log("복호화 완료");
        }

        string resultMessage = File.ReadAllText(decryptedPath);
        Debug.Log($"복호화 결과: {resultMessage}");
        Debug.Log($"원본과 일치: {originalMessage == resultMessage}");



    }

}
