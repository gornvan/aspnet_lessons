using CQSMediator.Contracts.CQS;
using CQSMediator.Contracts.CQS.Validation;
using CQSMediator.CQS;

namespace CQSMediator
{
    public struct ExecutableImplementations
    {
        public Type HandlerType { get; set; }
        public Type ValidatorType { get; set; }
    }

    public class CQSMediator : IMediator
    {
        private readonly Dictionary<Type, ExecutableImplementations> _queriesToImplementations;
        private readonly Dictionary<Type, ExecutableImplementations> _commandsToImplementations;
        private readonly IServiceProvider _serviceProvider;
        private readonly Type _unitOfWorkType;

        public CQSMediator(
            IServiceProvider serviceProvider,
            Type unitOfWorkType,
            Dictionary<Type, ExecutableImplementations> queriesToImplementations,
            Dictionary<Type, ExecutableImplementations> commandsToImplementations)
        {
            _serviceProvider = serviceProvider;
            _unitOfWorkType = unitOfWorkType;
            _queriesToImplementations = queriesToImplementations;
            _commandsToImplementations = commandsToImplementations;
        }

        public Task<object> Process(IQuery queryDto)
        {
            // find validator
            var implementations = _queriesToImplementations[queryDto.GetType()];
            return InternalProcess(queryDto, implementations);
        }

        public Task<object> Process(ICommand commandDto)
        {
            var implementations = _commandsToImplementations[commandDto.GetType()];
            return InternalProcess(commandDto, implementations);
        }

        private Task<object> InternalProcess<TDto>(TDto dto, ExecutableImplementations implementations)
        {
            // call validate
            var validatorConstructor = implementations.ValidatorType
                .GetConstructor(new[] { dto.GetType() });
            if(validatorConstructor == null)
            {
                throw new SystemException($@"Could not find a constructor for Validator of {dto.GetType().FullName}");
            }

            var validator = (IValidator) validatorConstructor.Invoke(new object[] { dto });
            if (validator == null)
            {
                throw new SystemException($@"Could not construct a Validator of {dto.GetType().FullName}");
            }

            validator.Validate();

            // call execute
            var unitOfWork = _serviceProvider.GetService(_unitOfWorkType);
            if (unitOfWork == null)
            {
                throw new SystemException($@"Could not get a UnitOfWork to execute {dto.GetType().FullName}");
            }


            var handlerConstructor = implementations.HandlerType
                .GetConstructor(new[] { dto.GetType(), unitOfWork.GetType() }  );
            if (handlerConstructor == null)
            {
                throw new SystemException($@"Could not find a constructor for Handler of {dto.GetType().FullName}");
            }

            var handler = (IHandler<object>) handlerConstructor.Invoke(new object[] { dto, unitOfWork });
            if (handler == null)
            {
                throw new SystemException($@"Could not construct a Handler of {dto.GetType().FullName}");
            }

            return handler.Execute();
        }
    }
}
