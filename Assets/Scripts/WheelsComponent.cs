using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cars
{
    public class WheelsComponent : MonoBehaviour
    {
        [SerializeField] private Transform[] m_frontTransform;
        [SerializeField] private Transform[] m_rearTransform;

        [Space, SerializeField] private WheelCollider[] m_frontWheels;
        [SerializeField] private WheelCollider[] m_rearWheels;
        private WheelCollider[] m_allWheels;

        public WheelCollider[] GetFrontWheels => m_frontWheels;
        public WheelCollider[] GetRearWheels => m_rearWheels;
        //public WheelCollider[] GetAllWheels => m_allWheels;

        private void Start()
        {
            //m_allWheels = new WheelCollider[] { m_frontWheels[0], m_frontWheels[1], m_rearWheels[0], m_rearWheels[1] };
        }

        public void UpdateVisual(float angle)
        {
            for (int i = 0; i < m_rearTransform. Length; i++)
            {
                m_frontWheels[i].steerAngle = angle;
                
                m_frontWheels[i].GetWorldPose(out var pos, out var rot);
                m_frontTransform[i].SetPositionAndRotation(pos,rot);
                
                m_rearWheels[i].GetWorldPose(out pos, out rot);
                m_rearTransform[i].SetPositionAndRotation(pos,rot);
            }
        }
    }
}