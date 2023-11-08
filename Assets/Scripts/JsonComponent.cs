using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Random = UnityEngine.Random;


namespace Race
{
    public class JsonComponent : MonoBehaviour
    {
        private  string m_file = "score.json";
        private  string m_path = "/Scripts";
        [SerializeField] private FinishComponent m_finishComp;
        [SerializeField] private GameManager m_gameManager;
        private string m_newName;
        private float m_newScore;

        public  Dictionary<string, float> scoreDic = new();
        public List<ScoreItem> scoreList = new List<ScoreItem>();

        private void Start()
        {
            Load();
        }

        public void AddScore()
        {
            m_newName = m_finishComp.GetName();
            m_newScore = m_finishComp.GetScore();

            if (scoreDic.ContainsKey(m_newName)) scoreDic[m_newName] = m_newScore;
            else scoreDic.Add(m_newName,m_newScore);
            
            Save();
        }
    
        public  void Save()
        {
            string json = JsonConvert.SerializeObject(scoreDic, Formatting.Indented);
            PlayerPrefs.SetString("test_score", json);
            Debug.LogError(json);
            InitializationsScoreList();
            m_gameManager.ShowLeaderBoard(scoreDic.Count + 1);
        }
        
        
        public  void Load()
        {
            string json = PlayerPrefs.GetString("test_score", "{}");
            scoreDic = JsonConvert.DeserializeObject<Dictionary<string, float>>(json);
            Debug.LogError(json);
        }

        private List<ScoreItem> InitializationsScoreList()
        {
            foreach (var pair in scoreDic)
            {
                ScoreItem item = new ScoreItem();
                item.name = pair.Key;
                item.score = pair.Value;
                scoreList.Add(item); 
            }
            
            var sortedPeople2 = scoreList.OrderBy(p => p.score);
            return sortedPeople2.ToList();
        }

        public class ScoreItem
        {
            public string name;
            public float score;
        }
}
    
}