using System;
using System.Collections;
using System.Collections.Generic;
using Cars;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Race
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private StartScript m_startScript;
        [SerializeField] private TimerComponent m_timer;
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private JsonComponent m_jsonComp;
        [SerializeField] private GameObject m_panel;
        [SerializeField] private ScrolComponent m_scrolComponent;
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
            PlayerInputOn(false);
            m_panel.SetActive(true);
        }
        
        public void ShowLeaderBoard()
        {
            m_scrolComponent.Inic();
        }
        

        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
            
    }
}