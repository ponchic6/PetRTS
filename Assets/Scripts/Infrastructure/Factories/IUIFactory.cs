using System.Collections.Generic;
using UnityEngine;

public interface IUIFactory
{   
    public Transform BuildingButtonsRoot { get; }
    public Transform UnitButtonsRoot { get; }
    public void CreatCanvas();
    public void CreatCreationPanel();
    public void CreatePanelOfSelectedObjects();
    public List<Transform> CreateUnitButtonsForBuilding(List<UnitConfig> unitList, List<Transform> buttonsList);
    public List<Transform> CreateBuildingButtonsForUnit(List<BuildingConfig> buildingList, List<Transform> buttonList);
    public void CreateIconOnSelectPanel(ViewSelectStatusChanger unit);
    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit);
}