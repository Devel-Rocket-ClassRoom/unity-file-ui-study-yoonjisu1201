//using Newtonsoft.Json;
//using System;
//using System.IO;
//using Unity.VisualScripting;
//using UnityEngine;
//using System.Collections.Generic;
//using Random = UnityEngine.Random;

//using static UnityEditor.PlayerSettings;

//[Serializable]
//public class SomeClass
//{
//    //public mesh
//    public Vector3 pos;
//    public Quaternion rot;
//    public Vector3 scale;
//    public Color color;
//}
//public class JsonTest2 : MonoBehaviour
//{
//    List<Transform> targets = new List<Transform>();
//    public Transform targetPrefab;
//    public List<Mesh> shapeMeshes;
//    public string fileName = "test.json";
//    public string FileFullPath => Path.Combine(Application.persistentDataPath, "JsonTest",fileName);

//    private JsonSerializerSettings jsonSettings;
//    private void Awake()
//    {
//        jsonSettings = new JsonSerializerSettings();
//        jsonSettings.Formatting = Formatting.Indented;
//        jsonSettings.Converters.Add(new Vector3Converter());
//        jsonSettings.Converters.Add(new QuaternionConverter());
//        jsonSettings.Converters.Add(new ColorConverter());

//    }


//    public void Save()
//    {
//        //SomeClass obj = new SomeClass();
//        //obj.pos = target.transform.position;
//        //obj.rot = target.transform.rotation;
//        //obj.scale = target.transform.localScale;
//        //obj.color = target.GetComponent<Renderer>().material.color;
//        //var json = JsonConvert.SerializeObject(obj, jsonSettings) ;
//        //File.WriteAllText(FileFullPath, json);

//        List<SomeClass> objs = new List<SomeClass>();
//        for (int i = 0; i < targets.Count; i++)
//        {
//            SomeClass some = new SomeClass();
//            some.pos = targets[i].position;
//            some.rot = targets[i].rotation;
//            some.scale = targets[i].localScale;
//            some.color = targets[i].GetComponent<Renderer>().material.color;
//            objs.Add(some);
//        }
//        var json = JsonConvert.SerializeObject(objs, jsonSettings);
//        File.WriteAllText(FileFullPath, json);
//    }
//    public void Load()
//    {
//        var json = File.ReadAllText(FileFullPath);
//        var objs = JsonConvert.DeserializeObject<List<SomeClass>>(json, jsonSettings);
//        Clear();
//        for (int i = 0; i < objs.Count; i++)
//        {
//            Transform obj = Instantiate(targetPrefab, Vector3.zero, Quaternion.identity);
//            targets.Add(obj);
//            targets[i].position = objs[i].pos;
//            targets[i].rotation = objs[i].rot;
//            targets[i].localScale = objs[i].scale;
//            targets[i].GetComponent<Renderer>().material.color = objs[i].color;
//        }
//    }
//    public void Create()
//    {
//        int ea = Random.Range(3, 11);
        
        
       
//        for (int i = 0; i < ea; i++)
//        {
//            Transform obj = Instantiate(targetPrefab, Vector3.zero, Quaternion.identity);
//            obj.position = new Vector3(Random.Range(-10f, 10f),
//                Random.Range(-4f, 4f), Random.Range(-10f, 10f));

//            obj.rotation = Quaternion.Euler(Random.Range(0, 360),
//                Random.Range(0, 360), Random.Range(0, 360));

//            obj.localScale = new Vector3(Random.Range(-4f, 4f),
//                Random.Range(-4f, 4f), Random.Range(-4f, 4f));

//            obj.GetComponent<Renderer>().material.color = Random.ColorHSV();
//            obj.GetComponent<MeshFilter>().mesh = shapeMeshes[Random.Range(0, 4)];

//            targets.Add(obj);
//        }
//    }
//    //public void Create()
//    //{

//    //}
//    public void Clear()
//    {

//    }
//}
