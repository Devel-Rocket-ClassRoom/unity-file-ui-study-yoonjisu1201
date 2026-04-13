using UnityEngine;
using System.IO;
using System.Collections.Generic;
using Unity.Collections;

public class Yoon : MonoBehaviour
{
    private void Start()
    {
        string filePath = "StudentData.csv";

        string[] lines = File.ReadAllLines(filePath);
        List<string> updatedLines = new List<string>();

        foreach (string line in lines)
        {
            string[] data = line.Split(',');

            if (data[0] == "전사루피")
            {
                data[1] = "11";

                string newLine = string.Join(",", data);
                updatedLines.Add(newLine);
            }
            else
            {
                updatedLines.Add(line);
            }
        }
        File.WriteAllLines(filePath, updatedLines);
    }
}
