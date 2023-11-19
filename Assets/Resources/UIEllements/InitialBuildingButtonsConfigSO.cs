using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "UIConfigs", fileName = "InitialBuildingButtonsConfig")]
public class InitialBuildingButtonsConfigSO : ScriptableObject
{
    [SerializeField] private List<BuildingConfig> _buildingConfigList;
    public List<BuildingConfig> BuildingConfigs => _buildingConfigList;
}
