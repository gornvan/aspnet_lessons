using CQSMediator.Contracts.CQS;
using CQSMediator.Contracts.CQS.Validation;
using CQSMediator.Contracts.Exceptions;
using System.Reflection;

namespace CQSMediator
{
    public class CQSMediatorBuilder
    {
        private static Dictionary<Type, ExecutableImplementations>? _queriesToImplementations;
        private static Dictionary<Type, ExecutableImplementations>? _commandsToImplementations;

        public static CQSMediator BuildMediatorWithExecutablesFromAssembly(
            Assembly assembly,
            IServiceProvider serviceProvider,
            Type unitOfWorkType
            )
        {
            var allTypes = assembly.GetTypes();

            if (_queriesToImplementations == null || _commandsToImplementations == null)
            {
                _queriesToImplementations = FindHandlersAndValidators_ForDTOMarkerType<IQuery>(allTypes);
                _commandsToImplementations = FindHandlersAndValidators_ForDTOMarkerType<ICommand>(allTypes);
            }

            return new CQSMediator(
                serviceProvider,
                unitOfWorkType,
                _queriesToImplementations,
                _commandsToImplementations
            );
        }

        private static Dictionary<Type, ExecutableImplementations> FindHandlersAndValidators_ForDTOMarkerType<DtoMarkerType>(Type[] allTypes){

            var dtoAndTheirHandlers = allTypes.Where(t => t.IsAssignableTo(typeof(DtoMarkerType)));

            var dtos = dtoAndTheirHandlers.Where(
                dtoOrHander => {
                    return !dtoOrHander.IsAssignableTo(typeof(IHandlerMarker)) &&
                           !dtoOrHander.IsAssignableTo(typeof(IValidator));
                }
            ).ToList();

            var dtoHandlers = dtoAndTheirHandlers.Where(
                dtoOrHander => dtoOrHander.IsAssignableTo(typeof(IHandlerMarker))
            ).ToList();

            // find all IHandler for those Commands
            var dtoToHandler = dtos.ToDictionary(
                dto => dto,
                dto => dtoHandlers.FirstOrDefault(ch => ch.IsAssignableTo(dto))
            );

            // find all IValidator for those Commands
            // a bit less verbose -- searching on the entire type list
            var dtoToValidator = dtos.ToDictionary(
                dto => dto,
                dto => allTypes.FirstOrDefault(
                    ch => ch.IsAssignableTo(dto) &&
                          ch.IsAssignableTo(typeof(IValidator))
                    )
            );

            return dtos.ToDictionary(
                dto => dto,
                dto =>
                {
                    var handler = dtoToHandler[dto];
                    if (handler == null)
                    {
                        throw new HandlerNotFoundException(dto.FullName);
                    }
                    var validator = dtoToValidator[dto];
                    if (validator == null)
                    {
                        throw new ValidatorNotFoundException(dto.FullName);
                    }

                    return new ExecutableImplementations
                    {
                        HandlerType = handler,
                        ValidatorType = validator,
                    };
                }
            );
        }

    }
}
