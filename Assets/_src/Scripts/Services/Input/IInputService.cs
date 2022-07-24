namespace CodeBase.Services.Input
{
    public interface IInputService : IService
    {
        public InputButtonHoldObserver LeftButtonObserver { get; }
        public InputButtonHoldObserver RightButtonObserver { get; }
        public InputButtonHoldObserver ButtonEObserver { get; }
        public InputButtonHoldObserver ButtonQObserver { get; }
    }
}