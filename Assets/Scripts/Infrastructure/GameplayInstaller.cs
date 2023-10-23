using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private TickService _tickService;
    private CameraMoverService _cameraMoverService;
    private InputService _inputService;
    public override void InstallBindings()
    {
        RegisterTickService();
        RegisterInputService();
        RegisterCameraMoveService();
        RegisterUIFactory();
    }

    private void RegisterUIFactory()
    {
        UIFactory uiFactory = Container.Instantiate<UIFactory>();
        Container.Bind<UIFactory>().FromInstance(uiFactory).AsSingle();
    }

    private void RegisterInputService()
    {
        _inputService = Container.Instantiate<InputService>();
        Container.Bind<IInputService>().FromInstance(_inputService).AsSingle();
    }

    private void RegisterCameraMoveService()
    {
        _cameraMoverService = Container.Instantiate<CameraMoverService>();
        Container.Bind<ICameraMoverService>().FromInstance(_cameraMoverService).AsSingle();
    }

    private void RegisterTickService()
    {
        Container.Bind<ITickService>().FromInstance(_tickService).AsSingle();
    }
}