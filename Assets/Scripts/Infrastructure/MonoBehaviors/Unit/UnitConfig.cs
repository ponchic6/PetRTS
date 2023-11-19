using System;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitConfig : MonoBehaviour
{
    [SerializeField] private Sprite _creationIcon;
    private Unit _unitType;
    public Sprite CreationIcon => _creationIcon;
    public Unit UnitType => _unitType;

    private void Awake()
    {
        _unitType = GetComponent<Unit>();
    }
}