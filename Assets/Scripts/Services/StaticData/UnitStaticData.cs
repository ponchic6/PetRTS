using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/Unit Static Data", fileName = "UnitStaticData")]
public class UnitStaticData : ScriptableObject
{
    [SerializeField] private string _unitPrefabPath;
    [SerializeField] private int _maxResourceOnUnit;
    [SerializeField] private Sprite _creationIcon;
    [SerializeField] private float _distanceForWork;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _efficiency;
    [SerializeField] private float _rotateDuration;
    [SerializeField] private float _price;

    public string UnitPrefabPath => _unitPrefabPath;
    public Sprite CreationIcon => _creationIcon;
    public float DistanceForWork => _distanceForWork;
    public float Cooldown => _cooldown;
    public float Efficiency => _efficiency;
    public int MaxResourceOnUnit => _maxResourceOnUnit;
    public float RotateDuration => _rotateDuration;
    public float Price => _price;
}