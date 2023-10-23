public interface IPayLoadState<TPayLoad> : IExitableState
{
    public void Enter(TPayLoad payLoad);
}