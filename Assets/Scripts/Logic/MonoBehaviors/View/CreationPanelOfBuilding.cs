using System.Collections.Generic;
using UnityEngine;

namespace Logic.MonoBehaviors.View
{
    public class CreationPanelOfBuilding : CreationPanelOfSelectedObject
    {
        [SerializeField] private List<UnitStaticData> _creatableUnits;
        
        private JobProgressData _buildingJobProgressData;

        protected override void Awake()
        {
            base.Awake();
        
            _buildingJobProgressData = GetComponent<JobProgressData>();
            _buildingJobProgressData.OnFinishedWorking += SwitchCreationPanelToCurrentObject;
        }

        protected override void SwitchCreationPanelToCurrentObject()
        {
            if (_buttonsListOfSelected == null &&
                _selectableListService.CurrentSelectObjects.Count == 1 &&
                !_buildingJobProgressData.HasObjectJob &&
                selectStatusChanger.IsSelect())
            {
                _buttonsListOfSelected = _uiFactory.CreateUnitCreationButtonsOfBuilding(_creatableUnits, transform);
            }
        }
    }
}