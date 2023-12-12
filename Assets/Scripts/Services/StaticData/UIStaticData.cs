using UnityEngine;

[CreateAssetMenu(menuName = "Static Data/UI Static Data", fileName = "UIStaticData")]
public class UIStaticData : ScriptableObject
{
    [SerializeField] private string _canvasPath;
    [SerializeField] private string _creationPanelPath;
    [SerializeField] private string _buildingButtonPath;
    [SerializeField] private string _panelOfSelectedPath;
    [SerializeField] private string _resourceCountPanelPath;
    [SerializeField] private string _unitButtonPath;
    [SerializeField] private string _buildingButtonsRootPath;
    [SerializeField] private string _unitButtonsRootPath;

    public string CanvasPath => _canvasPath;
    public string CreationPanelPath => _creationPanelPath;
    public string BuildingButtonPath => _buildingButtonPath;
    public string PanelOfSelectedPath => _panelOfSelectedPath;
    public string ResourceCountPanelPath => _resourceCountPanelPath;
    public string UnitButtonPath => _unitButtonPath;
    public string BuildingButtonsRootPath => _buildingButtonsRootPath;
    public string UnitButtonsRootPath => _unitButtonsRootPath;
}