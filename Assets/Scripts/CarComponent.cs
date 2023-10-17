using System;
using System.Collections;
using System.Collections.Generic;
using Cars;
using UnityEngine;

namespace Race
{
   [RequireComponent(typeof(WheelsComponent), typeof(BaseInputComponent), typeof(Rigidbody))] 
   public class CarComponent : MonoBehaviour
    {
        private WheelsComponent m_wheels;
        private BaseInputComponent m_input;
        private Rigidbody m_rb;

        [SerializeField, Range(5,50f)]private float m_maxSteerAngle = 25f;
        [SerializeField] private float m_torque = 2500f;
         private float m_handBrakeTorque = float.MaxValue;
        [SerializeField] private Vector3 m_centerMass;
        
        private void Start()
        {
            m_wheels = GetComponent<WheelsComponent>();
            m_input = GetComponent<BaseInputComponent>();
            m_rb = GetComponent<Rigidbody>();
            m_rb.centerOfMass = m_centerMass;
            m_input.OnHendBrakeEvent += OnHandBrake;
        }

        private void FixedUpdate()
        {
            m_wheels.UpdateVisual(m_input.Rotate * m_maxSteerAngle);
            var torque = m_input.Acceleration * m_torque / 2f;
            foreach (var wheel in m_wheels.GetRearWheels)
            {
                wheel.motorTorque = torque;
            }
        }

        private void OnHandBrake(bool value)
        {
            if (value)
            {
                foreach (var wheel in m_wheels.GetRearWheels)
                {
                    wheel.brakeTorque = m_handBrakeTorque;
                    wheel.motorTorque = 0f;
                }
            }
            else
            {
                foreach (var wheel in m_wheels.GetRearWheels)
                {
                    wheel.brakeTorque = 0f;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.TransformPoint(m_centerMass), .2f);
        }

        private void OnDestroy()
        {
            m_input.OnHendBrakeEvent -= OnHandBrake;
        }
    }
}