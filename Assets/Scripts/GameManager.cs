using System;
using System.Collections;
using System.Collections.Generic;
using Cars;
using Unity.VisualScripting;
using UnityEngine;

namespace Race
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private StartScript m_startScript;
        [SerializeField] private TimerComponent m_timer;
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private JsonComponent m_jsonComp;
        [SerializeField] private FinishComponent m_finishComp;
        [SerializeField] private GameObject m_panel;
        private float m_curScore;
        private string m_name;
        
        private void Start()
        {
            
            m_startScript.StartCountdown();
        }

        public void StartRace()
        {
            m_timer.StartCountRaceTime();
        }

        public void PlayerInputOn(bool input)
        {
            m_playerController.OnPlayerInput(input);
        }
        
        public void EndRace(float score)
        {
            m_curScore = score;
            PlayerInputOn(false);
            m_panel.SetActive(true);
        }

        public void AddNewScore()
        {
            m_jsonComp.AddScore(m_finishComp.GetPlayerName(), m_curScore);
            m_jsonComp.Save();
        }

        public float GetScore()
        {
            return m_curScore;
        }
    }
}