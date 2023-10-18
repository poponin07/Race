using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Race
{

    public class FinishComponent : MonoBehaviour
    {
        [SerializeField] private TimerComponent m_timerComp;
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponentInParent<PlayerController>() != null)
            {
                m_timerComp.StopRaceTimer();
            }
        }
    }
}