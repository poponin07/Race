using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Newtonsoft.Json;
using Unity.VisualScripting;
using Random = UnityEngine.Random;


namespace Race
{
    public class JsonComponent : MonoBehaviour
    {
        private  string m_file = "score.json";
        private  string m_path = "/Scripts";

         static Dictionary<string, float> _score = new();

         private void Start()
         {
             Load();
         }

         public void AddScore(string name, float score)
         {
             Math.Round(score,0);
             _score.Add(name, score);
         }
         
         public  void Save()
        {
            
            string json = JsonConvert.SerializeObject(_score, Formatting.Indented);
            PlayerPrefs.SetString("test_score", json);

            Debug.LogError(json);
        }
        
        
        public  void Load()
        {
            string json = PlayerPrefs.GetString("test_score", "{}");
            
            _score = JsonConvert.DeserializeObject<Dictionary<string, float>>(json);
            Debug.LogError(json);
        }
        
}
    
}