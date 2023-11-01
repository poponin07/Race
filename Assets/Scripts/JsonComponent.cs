using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using Random = UnityEngine.Random;


namespace Race
{
    public class JsonComponent : MonoBehaviour
    {
        private static string m_file = "score.json";
        private static string m_path = "/Scripts";

        private static Dictionary<string, int> score = new()
        {

        };
        
        public static void Save()
        {
            string json = JsonConvert.SerializeObject(score, Formatting.Indented);
            PlayerPrefs.SetString("test_score", json);

            Debug.LogError(json);
        }
        
        
        public static void Load()
        {
            string json = PlayerPrefs.GetString("test_score", "{}");
            score = JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
            Debug.LogError(json);
        }
        
}
    
}