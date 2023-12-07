using System.Collections.Generic;
using UnityEngine;

public interface IUIFactory
{   
    public Transform ResourceCountPanel { get; }
    public void CreatCanvas();
    public void CreatCreationPanel();
    public void CreatePanelOfSelectedObjects();
    public void CreateResourceCountPanel();
    public List<Transform> CreateUnitCreationButtons(List<UnitStaticData> unitList, List<Transform> buttonsList,
        Transform building);
    public List<Transform> CreateBuildingCreationButtons(List<Building> buildingList, List<Transform> buttonList);
    public void CreateIconOnSelectPanel(ViewSelectStatusChanger unit);
    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit);
}