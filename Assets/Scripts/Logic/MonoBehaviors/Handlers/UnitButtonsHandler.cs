using Logic.MonoBehaviors.Mediators;
using UnityEngine;
using Zenject;

namespace Logic.MonoBehaviors.Handlers
{
    public class UnitButtonsHandler : MonoBehaviour
    {
        private IGlobalResourceAndUnitFactoryMediator _unitMediator;

        [Inject]
        public void Constructor(IGlobalResourceAndUnitFactoryMediator unitMediator)
        {
            _unitMediator = unitMediator;
        }

        public void CreateUnit(UnitStaticData unit, Transform building)
        {
            _unitMediator.CreateUnit(unit, building);
        }
    }
}