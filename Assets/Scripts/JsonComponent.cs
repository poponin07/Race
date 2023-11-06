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
        private  string m_file = "score.json";
        private  string m_path = "/Scripts";
        [SerializeField] private FinishComponent m_finishComp;
        private string m_newName;
        private float m_newScore;

        public  Dictionary<string, float> score = new()
        {
        };

        private void Start()
        {
            Load();
        }

        public void AddScore()
        {
            m_newName = m_finishComp.GetName();
            m_newScore = m_finishComp.GetScore();
            score.Add(m_newName,m_newScore);
            Save();
        }
    
        public  void Save()
        {
            string json = JsonConvert.SerializeObject(score, Formatting.Indented);
            PlayerPrefs.SetString("test_score", json);
            Debug.LogError(json);
        }
        
        
        public  void Load()
        {
            string json = PlayerPrefs.GetString("test_score", "{}");
            score = JsonConvert.DeserializeObject<Dictionary<string, float>>(json);
            Debug.LogError(json);
        }
        
}
    
}