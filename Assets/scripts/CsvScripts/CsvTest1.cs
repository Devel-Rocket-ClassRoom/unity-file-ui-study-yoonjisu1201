using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;
public class CSVData
{
    public string Id {  get; set; }
    public string String {  get; set; }

}


public class CsvTest1 : MonoBehaviour
{
    //public TextAsset textAsset;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //이 코드 실행할 때 메모리에 올라감
            TextAsset textAsset = Resources.Load<TextAsset>("DataTables/StringTableKr");
            string csv = textAsset.text;
            using (var reader = new StringReader(csv))
            using (var csvReder = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //GetRecords<> -> CSV의 각 행을 제네릭 타입 T의 객체로 자동 변환함
                var records = csvReder.GetRecords<CSVData>();
                foreach (var record in records)
                {
                    Debug.Log($"{record.Id} : {record.String}");
                }
            }
        }
    }

}
