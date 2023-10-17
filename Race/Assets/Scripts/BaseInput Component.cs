using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

namespace Race
{
    public abstract class BaseInputComponent : MonoBehaviour
    {
    public float Acceleration { get; protected set; }
    public float Rotate { get; protected set; }
    public event Action<bool> OnHendBrakeEvent;
    
    protected abstract void FixedUpdate();

    protected void CallHandBrake(bool value) => OnHendBrakeEvent?.Invoke(value);
    }
    
}