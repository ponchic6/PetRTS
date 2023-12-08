using System.Collections.Generic;

public interface IWorkingWorkersList
{
    public List<IMoveble> GetList();
    public void AddUnit(IMoveble unit);
    public void TryRemoveUnit(IMoveble unit);
    public float Count();
}