using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/Create Static Data Parent", fileName = "_StaticData", order = 0)]
public class StaticData : ScriptableObject
{
    [SerializeReference] private UnitStaticData _unitStaticData;
    
    public UnitStaticData UnitStaticData => _unitStaticData;
}