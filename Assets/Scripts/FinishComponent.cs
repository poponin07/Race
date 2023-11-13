using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Race
{

    public class FinishComponent : MonoBehaviour
    {
        [SerializeField] private TimerComponent m_timerComp;
        [SerializeField] private GameManager m_gm;
        [SerializeField] private Text m_scoreText;
        [SerializeField] private InputField m_inputField;
        string m_playerName;
        private float m_score;

        public string GetName() //возвращает имя игрока
        {
            return m_playerName;
        }

        public float GetScore() //возвращает время игрока
        {
            return m_score;
        }
        

        public void SetPlayerName() // имя игрока
        {
            m_playerName = m_inputField.text;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<PlayerController>() != null)
            {
                m_score = m_timerComp.StopRaceTimer();
                TimeSpan ts = TimeSpan.FromMilliseconds(m_score);
                m_scoreText.text = string.Format("{0:mm}: {0:ss}: {0:%f}", ts);
                m_gm.EndRace();
            }
        }
    }
}