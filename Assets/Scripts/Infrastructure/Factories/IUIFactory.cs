using System.Collections.Generic;
using UnityEngine;

public interface IUIFactory
{   
    public Transform BuildingButtonsRoot { get; }
    public Transform UnitButtonsRoot { get; }
    public Transform CreatCanvas();
    public Transform CreatCreationPanel();
    public Transform CreatePanelOfSelectedObjects();
    public Transform CreateBuildingButton(BuildingConfig buildingConfig);
    public Transform CreateUnitButton(UnitConfig unit);
    public List<Transform> CreateUnitButtonsForBuilding(List<UnitConfig> unitList, List<Transform> buttonsList);
    public void CreateInitialBuildButtons();
    public Transform CreateIconOnSelectPanel(ViewSelectStatusChanger unit);
    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit);
}