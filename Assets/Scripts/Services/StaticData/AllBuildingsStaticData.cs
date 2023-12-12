using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/All Buildings Static Data", fileName = "AllBuildingStaticData", order = 0)]
public class AllBuildingsStaticData : ScriptableObject
{
    [SerializeReference] private BuildingStaticData _castleStaticData;

    public BuildingStaticData CastleStaticData => _castleStaticData;
}