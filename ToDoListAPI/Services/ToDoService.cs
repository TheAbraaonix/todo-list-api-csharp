using AutoMapper;
using ToDoListAPI.Entities;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;

namespace ToDoListAPI.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;
        private readonly IMapper _mapper;

        public ToDoService(IToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ToDoViewModel> GetAll()
        {
            IEnumerable<ToDo> toDos = _repository.GetAll();
            IEnumerable<ToDoViewModel> toDosViewModel = _mapper.Map<IEnumerable<ToDoViewModel>>(toDos);
            return toDosViewModel;
        }

        public ToDoViewModel GetById(Guid id)
        {
            ToDo? toDo = _repository.GetById(id);

            if (toDo == null) return null;

            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public ToDoViewModel Create(ToDoInputModel input)
        {
            if (input == null) return null;

            ToDo toDo = _mapper.Map<ToDo>(input);
            _repository.Create(toDo);
            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public ToDoViewModel Update(Guid id, ToDoInputModel input)
        {
            ToDo? toDo = _repository.GetById(id);

            if (toDo == null) return null;

            toDo.Name = input.Name;
            toDo.Description = input.Description;
            toDo.Priority = input.Priority;
            toDo.IsCompleted = input.IsCompleted;

            _repository.Update(toDo);
            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public ToDoViewModel Delete(Guid id)
        {
            ToDo? toDo = _repository.GetById(id);

            if (toDo == null) return null;

            _repository.Delete(toDo);
            return _mapper.Map<ToDoViewModel>(toDo);
        }
    }
}
