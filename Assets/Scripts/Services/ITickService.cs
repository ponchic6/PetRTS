using System;

namespace Services
{
    public interface ITickService
    {
        public event Action OnTick;
        public event Action OnFixedTick;
        public event Action OnLateTick;
    }
}