using API.Commands.Contracts;
using System.Collections.Generic;

namespace API.Managers
{
    public sealed class CommandManager
    {
        private readonly static List<ICommand> _commands = new List<ICommand>();
        private static readonly object commandListLock = new object();

        CommandManager()
        {
        }

        public static bool Invoke(ICommand command)
        {
            try
            {
                var succesfullyExecuted = command.Execute();
                lock (commandListLock)
                {
                    if (succesfullyExecuted)
                        _commands.Add(command);
                    return succesfullyExecuted;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
