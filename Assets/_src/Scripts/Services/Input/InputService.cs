namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        private InputActions _controls;

        public InputButtonHoldObserver LeftButtonObserver { get; }
        public InputButtonHoldObserver RightButtonObserver { get; }
        public InputButtonHoldObserver ButtonEObserver { get; }
        public InputButtonHoldObserver ButtonQObserver { get; }        

        public InputService() {
            _controls = new InputActions();

            LeftButtonObserver = new InputButtonHoldObserver(_controls.Player.MouseLeft);
            LeftButtonObserver.Enable();

            RightButtonObserver = new InputButtonHoldObserver(_controls.Player.MouseRight);
            RightButtonObserver.Enable();

            ButtonEObserver = new InputButtonHoldObserver(_controls.Player.ButtonE);
            ButtonEObserver.Enable();

            ButtonQObserver = new InputButtonHoldObserver(_controls.Player.ButtonQ);
            ButtonQObserver.Enable();

            _controls.Enable();
        }
    }
}