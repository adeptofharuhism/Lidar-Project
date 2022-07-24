using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    [DefaultExecutionOrder(-80)]
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake() {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}
