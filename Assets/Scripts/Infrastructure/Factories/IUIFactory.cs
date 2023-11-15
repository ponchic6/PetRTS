using UnityEngine;

public interface IUIFactory
{   
    public Transform RootCanvas { get; }
    public Transform BuildingPannel { get; }
    public Transform BuildingButtons { get; }
    public Transform PanelOfSelected { get; }
    public Transform UnitsButtons { get; }
    public Transform CreatCanvas();
    public Transform CreatBuildingListPanel();
    public Transform CreateBuildButtons();
    public Transform CreateUnitsButtons();
    public Transform CreatePanelOfSelectedObjects();
    public Transform CreateIconOnSelectPanel(ViewSelectStatusChanger unit);
    public void DestroyIconOnSelectPanel(ViewSelectStatusChanger unit);
}