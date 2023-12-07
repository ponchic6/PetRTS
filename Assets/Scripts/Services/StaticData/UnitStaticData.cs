using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/Unit Static Data", fileName = "UnitStaticData")]
public class UnitStaticData : ScriptableObject
{
    [SerializeField] private int _maxResourceOnUnit;
    [SerializeField] private Sprite _creationIcon;
    [SerializeField] private UnitTypeEnum _unitType;
    [SerializeField] private float _distanceForWork;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _efficiency;
    [SerializeField] private float _rotateDuration;
    
    public Sprite CreationIcon => _creationIcon;
    public UnitTypeEnum UnitType => _unitType;
    public float DistanceForWork => _distanceForWork;
    public float Cooldown => _cooldown;
    public float Efficiency => _efficiency;
    public int MaxResourceOnUnit => _maxResourceOnUnit;
    public float RotateDuration => _rotateDuration;

}