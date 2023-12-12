using Factories;
using UnityEngine;
using Zenject;

namespace Logic.MonoBehaviors.Handlers
{
    public class UnitButtonsHandler : MonoBehaviour
    {
        private IUnitFactory _unitFactory;

        [Inject]
        public void Constructor(IUnitFactory unitFactory)
        {
            _unitFactory = unitFactory;
        }

        public void CreateUnit(UnitStaticData unit, Transform building)
        {
            _unitFactory.CreateUnit(unit, building);
        }
    }
}