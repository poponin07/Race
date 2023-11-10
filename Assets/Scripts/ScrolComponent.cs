using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Race
{
    public class ScrolComponent : MonoBehaviour
    {
        [SerializeField] private JsonComponent m_jsonComponent;
        [SerializeField] private RectTransform prefab;
        [SerializeField] private RectTransform content;
        private int m_countPanels;
        private Dictionary<string, float> scoreDictionary;
        private List<float> scoreList;
        
        public void Inic()
        {
            var nameScoreList = m_jsonComponent.GetScoreList();
            m_countPanels = nameScoreList.Count;
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

            OnReceivedModels(results);
        }

        private void OnReceivedModels(ItemSoreView[] models)
        {
            foreach (Transform child in content)
            {
               Destroy(child.gameObject);
            }

            foreach (var model in models)
            {
                var instance = Instantiate(prefab.gameObject);
                instance.transform.SetParent(content,false);
                InitializeItemView(instance, model);
            }
        }

        void InitializeItemView(GameObject viewGameObject, ItemSoreView model)
        {
            ScorePanel view = new ScorePanel(viewGameObject.transform);
            view.placeText.text = model.place;
            view.nameText.text = model.name;
            view.scoreText.text = model.score;

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
            
            public ScorePanel(Transform rootView)
            {
                placeText = rootView.Find("position").GetComponent<Text>();
                nameText = rootView.Find("name").GetComponent<Text>();
                scoreText = rootView.Find("score").GetComponent<Text>();
            }
        }
    }
}