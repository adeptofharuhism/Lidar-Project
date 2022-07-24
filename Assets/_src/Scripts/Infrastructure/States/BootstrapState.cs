using CodeBase.Services;
using CodeBase.Services.Input;

namespace CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        private const string Main = "Main";

        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        private AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services) {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter() {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        public void Exit() { }

        private void EnterLoadLevel() =>
            _stateMachine.Enter<LoadLevelState, string>(Main);

        private void RegisterServices() {
            _services.RegisterSingle<IInputService>(new InputService());
        }
    }
}
