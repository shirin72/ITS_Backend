using MediatR;

namespace ITS.Commands.Modules.Base
{
    public abstract class CommandBase : IRequest
    {
        public abstract void Validate();
    }
    public abstract class CommandBase<T> : IRequest<T>
    {
        public abstract void Validate();
    }
}