using Zenject;

public class Game
{
    public GameStateMachine StateMachine;

    public Game(ICoroutineRunner coroutineRunner, DiContainer diContainer)
    {
        StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), diContainer);
    }
}