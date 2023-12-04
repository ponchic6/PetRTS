using System.Collections.Generic;
using UnityEngine;

public interface IUIFactory
{   
    public Transform BuildingButtonsRoot { get; }
    public Transform UnitButtonsRoot { get; }
    public void CreatCanvas();
    public void CreatCreationPanel();
    public void CreatePanelOfSelectedObjects();
    public List<Transform> CreateUnitCreationButtons(List<UnitConfig> unitList, List<Transform> buttonsList,
        Transform building);
    public List<Transform> CreateBuildingCreationButtons(List<Building> buildingList, List<Transform> buttonList);
    public void CreateIconOnSelectPanel(ViewSelectStatusChanger unit);
    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit);
}