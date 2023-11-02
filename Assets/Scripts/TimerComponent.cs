using System;
using System.Collections;
using System.Collections.Generic;
using Cars;
using UnityEngine;
using UnityEngine.UI;

namespace Race
{
    
public class TimerComponent : MonoBehaviour
{
   [SerializeField] private Text m_raceTimerText;
   private float m_raceTime;
   private Coroutine m_raceTimerCor;
   private float m_startTimer = 3;
   private float m_msec;
   public float GetRaceTime() =>  m_raceTime;

   public void StartCountRaceTime()
   {
      m_raceTimerCor = StartCoroutine(CountRaceTimer());
   }

   public float StopRaceTimer()
   {
      StopCoroutine(m_raceTimerCor);
      return m_msec;
   }
   
   IEnumerator  CountRaceTimer()
   {
      while (true)
     {
         m_msec += Time.deltaTime * 1000;
         TimeSpan ts = TimeSpan.FromMilliseconds(m_msec);
         m_raceTimerText.text = string.Format("{0:mm}: {0:ss}: {0:%f}", ts);
         yield return null;
     }
   }
}
}