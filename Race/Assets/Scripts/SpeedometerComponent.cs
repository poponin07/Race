using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cars
{
    public class SpeedometerComponent : MonoBehaviour
    {
        private const float m_convertMeterinSecFromKmInH = 3.6f;
        [SerializeField] private Transform m_player;

        [SerializeField] private float m_maxSpeed;
        [SerializeField] private Color m_minColor = Color.yellow;
        [SerializeField] private Color m_maxColor = Color.red;

        [Space, SerializeField, Range(0.1f, 1f)]
        private float m_delay = 0.3f;

        [SerializeField] private Text m_text;

        private void Start()
        {
            StartCoroutine(Speed());
        }

        private IEnumerator Speed()
        {
            var prevPos = m_player.position;
            while (true)
            {
                var distace = Vector3.Distance(prevPos, m_player.position);
                var speed = (float)System.Math.Round(distace / m_delay * m_convertMeterinSecFromKmInH, 1);

                m_text.color = Color.Lerp(m_minColor, m_maxColor, speed / m_maxSpeed);
                m_text.text = speed.ToString();
                prevPos = m_player.position;

                yield return new WaitForSeconds(m_delay);
            }
        }

    }
}