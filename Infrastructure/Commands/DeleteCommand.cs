using API.Commands.Contracts;
using Core.Models;
using Infrastructure.Repositories.Contracts;
using System;

namespace API.Commands
{
    public class DeleteCommand<T> : ICommand
    {
        private readonly Guid _id;
        private readonly IWriteRepository<T> _deleteRepository;
        private readonly IReadOnlyRepository<T> _readRepository;

        public DeleteCommand(Guid id, IWriteRepository<T> deleteRepository, IReadOnlyRepository<T> readRepository)
        {
            _id = id;
            _deleteRepository = deleteRepository;
            _readRepository = readRepository;
        }

        public bool Execute()
        {
            return _deleteRepository.Remove(_readRepository.Find(_id)) != null;
        }
    }
}
