using System.Collections.Generic;
using Logic.MonoBehaviors.Unit;
using Logic.MonoBehaviors.View;
using UnityEngine;

namespace Services
{
    public class DestinationOfGroupUnitsSetter
    {
        private readonly IInputService _inputService;
        private readonly SelectableListService _selectableListService;

        public DestinationOfGroupUnitsSetter(IInputService inputService, SelectableListService selectableListService)
        {
            _inputService = inputService;
            _inputService.OnRightClickDown += SetDestinationOnGround;
        
            _selectableListService = selectableListService;
        }

        private void SetDestinationOnGround()
        {   
            Ray ray = Camera.main.ScreenPointToRay(_inputService.GetCursorPos());
            RaycastHit raycastHit;

            Physics.Raycast(ray, out raycastHit, Mathf.Infinity, 1 << 6);

            List<IMoveble> _currentSelectUnits = FillCurrentSelectMovebleUnitList();

            int numberInColumn = Mathf.RoundToInt(Mathf.Sqrt(_currentSelectUnits.Count));

            int i = 0;
            int j = 0;

            Vector3 midlePoint = new Vector3();

            foreach (IMoveble unit in _currentSelectUnits)
            {
                midlePoint += unit.Transform.position / _currentSelectUnits.Count;
            }

            Vector3 verticalDirection = (raycastHit.point - midlePoint).normalized / 1.6f;
            Vector3 horizontalDirecton = new Vector3(1, 0, -(verticalDirection.x / verticalDirection.z)).normalized / 1.6f;

            foreach (IMoveble unit in _currentSelectUnits)
            {
                unit.MoveToDestination(raycastHit.point +
                                       (i - Mathf.RoundToInt(numberInColumn / 2)) * verticalDirection +
                                       (j - Mathf.RoundToInt(numberInColumn / 2)) * horizontalDirecton);
                i++;

                if (i == numberInColumn)
                {
                    i = 0;
                    j += 1;
                }
            }
        }

        private List<IMoveble> FillCurrentSelectMovebleUnitList()
        {
            List<IMoveble> currentUnits = new List<IMoveble>();

            foreach (SelectStatusChanger unit in _selectableListService.CurrentSelectObjects)
            {
                if (unit.TryGetComponent(out IMoveble unitMover))
                {
                    currentUnits.Add(unitMover);
                }
            }

            return currentUnits;
        }
    }
}