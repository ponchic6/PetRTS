using System;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitConfig : MonoBehaviour
{   
    [SerializeField] private int _maxResourceOnUnit;
    [SerializeField] private Sprite _creationIcon;
    [SerializeField] private Unit _unitType;
    [SerializeField] private float _distanceForWork;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _efficiency;
    
    public Sprite CreationIcon => _creationIcon;
    public Unit UnitType => _unitType;
    public float DistanceForWork => _distanceForWork;
    public float Cooldown => _cooldown;
    public float Efficiency => _efficiency;
    public int MaxResourceOnUnit => _maxResourceOnUnit;
}