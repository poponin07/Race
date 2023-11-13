using System;
using System.Collections;
using System.Collections.Generic;
using Race;
using UnityEngine;
using UnityEngine.UI;

namespace Cars
{
    public class StartScript : MonoBehaviour
    {
        [SerializeField]private Text m_startCountdown;
        [SerializeField] private int m_startCountMax;
        [SerializeField] private GameManager m_gameManaer;

        public void StartCountdown() //отчет на старте
        {
            StartCoroutine(StartCountdownCorut());
        }
        
        IEnumerator StartCountdownCorut() //отсчет на старте
        {
            int indx = m_startCountMax;
            m_gameManaer.PlayerInputOn(false);
            
            while (indx != -1)
            {
                if (indx == 0) m_startCountdown.text = "GO";
                else m_startCountdown.text = indx.ToString();
                m_startCountdown.gameObject.SetActive(true);
                indx--;
                yield return new WaitForSeconds(1);
 
            }
            m_startCountdown.gameObject.SetActive(false);
            m_gameManaer.PlayerInputOn(true);
            m_gameManaer.StartRace();
        }
    }
}