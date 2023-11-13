using System;
using System.Collections;
using System.Collections.Generic;
using Cars;
using UnityEngine;
using UnityEngine.UIElements;

namespace Race
{
    public class PlayerController : BaseInputComponent
    {
        private CarControls m_controls;

        private void OnEnable()
        {
            m_controls = new CarControls();
            m_controls.Car.handBrake.performed += _ => CallHandBrake(true);
            m_controls.Car.handBrake.canceled += _ => CallHandBrake(false);
        }

        public void OnPlayerInput(bool inputValue) // управление инфпутом
        {
            if (inputValue) m_controls.Car.Enable();
            else m_controls.Car.Disable();
        }

        protected override void FixedUpdate()
        {
            var direction = m_controls.Car.Rotate.ReadValue<float>();
            if (direction == 0f)
            {
                Rotate = Rotate > 0f
                    ? Rotate - Time.fixedDeltaTime
                    : Rotate + Time.fixedDeltaTime;
            }
            else
            {
                Rotate = Math.Clamp(Rotate + direction * Time.deltaTime, -1f, 1f);
            }
            
            Acceleration = m_controls.Car.Acceleration.ReadValue<float>();
        }

        private void OnDisable()
        {
            m_controls.Car.Disable();
        }

        private void OnDestroy()
        {
            m_controls.Dispose();
        }
    }
}