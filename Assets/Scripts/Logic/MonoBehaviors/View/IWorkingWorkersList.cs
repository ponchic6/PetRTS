using System.Collections.Generic;

public interface IWorkingWorkersList
{
    public List<IMoveble> GetList();
    public void TryRemoveUnit(IMoveble unit);

}