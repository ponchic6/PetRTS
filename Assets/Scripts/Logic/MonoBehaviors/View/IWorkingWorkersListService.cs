using System.Collections.Generic;
using Logic.MonoBehaviors.Unit;

namespace Logic.MonoBehaviors.View
{
    public interface IWorkingWorkersListService
    {
        public List<IMoveble> GetList();
        public void TryAdd(IMoveble unit);
        public void TryRemoveUnit(IMoveble unit);
        public void SetDestination(IMoveble unitMover);

    }
}