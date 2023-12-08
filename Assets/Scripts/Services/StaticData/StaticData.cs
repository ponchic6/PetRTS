using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Static Data/Create Static Data Parent", fileName = "_StaticData", order = 0)]
public class StaticData : ScriptableObject
{
    [SerializeReference] private UnitStaticData _unitStaticDataWorker;
    [SerializeReference] private UnitStaticData _unitStaticDataKnight;
    [SerializeReference] private UnitStaticData _unitStaticDataBower;
    [SerializeReference] private UnitStaticData _unitStaticDataWizard;

    public UnitStaticData UnitStaticDataWorker => _unitStaticDataWorker;
    public UnitStaticData UnitStaticDataKnight => _unitStaticDataKnight;
    public UnitStaticData UnitStaticDataBower => _unitStaticDataBower;
    public UnitStaticData UnitStaticDataWizard => _unitStaticDataWizard;
}