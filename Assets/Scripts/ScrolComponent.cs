using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Race
{
    public class ScrolComponent : MonoBehaviour
    {
        [SerializeField] private JsonComponent m_jsonComponent;
        private RectTransform prefab;
        private RectTransform content;
        private int m_countPanels;
        private Dictionary<string, float> scoreDictionary;
        private List<float> scoreList;
        


        public void Inic()
        {
            var nameScoreList = m_jsonComponent.GetScoreList();
            m_countPanels = nameScoreList.Count + 1;
            var results = new ItemSoreView[m_countPanels];
            for (int i = 0; i < m_countPanels; i++)
            {
                 int inx = i + 1;
                results[i] = new ItemSoreView();
                results[i].place = inx.ToString();
                results[i].name = nameScoreList[i].name;
                TimeSpan ts = TimeSpan.FromMilliseconds(nameScoreList[i].score);
                results[i].score = string.Format("{0:mm}: {0:ss}: {0:%f}", ts);
            }
        }
        
        public class ItemSoreView
        {
            public string place;
            public string name;
            public string score;
        }

        public class ScorePanel
        {
            public Text placeText;
            public Text nameText;
            public Text scoreText;
        }
    }
}