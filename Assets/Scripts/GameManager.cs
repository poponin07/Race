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
        
        public void EndRace()
        {
            
        }
    }
}