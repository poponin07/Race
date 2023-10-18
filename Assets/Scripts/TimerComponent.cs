using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Race
{
    
public class TimerComponent : MonoBehaviour
{
   [SerializeField] private Text m_raceTimerText;
   [SerializeField] private Text m_startTimerText;
   private float m_raceTime;
   private Coroutine m_raceTimerCor;
   private float m_startTimer = 3;

   private float m_min;
   private float m_sec;
   private float m_msec;
   private float aaa = 0.0001f;

   private void Start()
   {
      StartCountRaceTime();
   }

   public float GetRaceTime() =>  m_raceTime;

   public void StartCountRaceTime()
   {
      m_raceTimerCor = StartCoroutine(CountRaceTimer());
   }

   public void StopRaceTimer()
   {
      StopCoroutine(m_raceTimerCor);
   }
   
   IEnumerator  CountRaceTimer()
   {
      //if (m_raceTime != 0) m_raceTime = 0f;
      m_msec = m_sec = m_min = 0f;
      float inx = 0f;
         while (true)
         {
            m_raceTimerText.text = $"time {m_min.ToString("00")}:{m_sec.ToString("00")}:{m_msec}";
            
            inx += Time.deltaTime;
            
            if (inx > 0.099)
            {
               inx = 0f;
               m_msec++;
            }
            if (m_msec > 9f)
            {
               m_msec = 0f;
               m_sec++;
            }
            
            if (m_sec > 59f)
            {
               m_sec = 0f;
               m_min++;
            }
            
           
         yield return null;
      }
      
   }
}
}