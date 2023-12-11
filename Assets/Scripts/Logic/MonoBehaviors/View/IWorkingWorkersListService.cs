using System.Collections.Generic;

public interface IWorkingWorkersListService
{
    public List<IMoveble> GetList();
    public void TryAdd(IMoveble unit);
    public void TryRemoveUnit(IMoveble unit);
    public void SetDestination(IMoveble unitMover);

}