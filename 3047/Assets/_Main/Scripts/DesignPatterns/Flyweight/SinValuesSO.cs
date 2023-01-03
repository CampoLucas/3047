using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SineValues", menuName = "Entities/SineValues", order = 0)]
public class SinValuesSO : ScriptableObject
{

    public float Amplitude => _amplitude;
    [SerializeField] private float _amplitude;
    public float Frequency => _frequency;
    [SerializeField] private float _frequency;
}
