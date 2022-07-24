using CodeBase.Infrastructure.States;
using CodeBase.Services;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        private GameStateMachine _stateMachine;

        public GameStateMachine StateMachine => _stateMachine;

        public Game(ICoroutineRunner coroutineRunner) {
            _stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}
