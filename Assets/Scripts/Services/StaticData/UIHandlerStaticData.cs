using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/UI Handler Static Data", fileName = "UIHandlerStaticData")]
public class UIHandlerStaticData : ScriptableObject
{
    [SerializeField] private string _buildingButtonsHandlerPath;
    [SerializeField] private string _selectorViewPath;
    [SerializeField] private string _unitbuttonsHandlerPath;

    public string BuildingButtonsHandlerPath => _buildingButtonsHandlerPath;
    public string SelectorViewPath => _selectorViewPath;
    public string UnitbuttonsHandlerPath => _unitbuttonsHandlerPath;
}