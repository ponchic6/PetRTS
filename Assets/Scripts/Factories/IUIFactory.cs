using System.Collections.Generic;
using Logic.MonoBehaviors.View;
using UnityEngine;

namespace Factories
{
    public interface IUIFactory
    {   
        public Transform ResourceCountPanel { get; }
        public void CreatCanvas();
        public void CreatCreationPanel();
        public void CreatePanelOfSelectedObjects();
        public void CreateResourceCountPanel();
        public List<Transform> CreateUnitCreationButtonsOfBuilding(List<UnitStaticData> unitList, Transform building);
        public List<Transform> CreateBuildingCreationButtonsOfUnit(List<BuildingStaticData> buildingList);
        public void CreateIconOnSelectPanel(SelectStatusChanger unit);
        public void DestroyIconOnSelectPanel(SelectStatusChanger unit);
    }
}