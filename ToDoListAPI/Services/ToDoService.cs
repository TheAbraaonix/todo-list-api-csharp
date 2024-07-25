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

        public async Task<IEnumerable<ToDoViewModel>> GetAll()
        {
            IEnumerable<ToDo> toDos = await _repository.GetAllAsync();
            IEnumerable<ToDoViewModel> toDosViewModel = _mapper.Map<IEnumerable<ToDoViewModel>>(toDos);
            return toDosViewModel;
        }

        public async Task<ToDoViewModel> GetById(Guid id)
        {
            ToDo? toDo = await _repository.GetByIdAsync(id);

            if (toDo == null) return null;

            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public async Task<ToDoViewModel> Create(ToDoInputModel input)
        {
            if (input == null) return null;

            ToDo toDo = _mapper.Map<ToDo>(input);
            await _repository.CreateAsync(toDo);
            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public async Task<ToDoViewModel> Update(Guid id, ToDoInputModel input)
        {
            ToDo? toDo = await _repository.GetByIdAsync(id);

            if (toDo == null) return null;

            toDo.Name = input.Name;
            toDo.Description = input.Description;
            toDo.Priority = input.Priority;
            toDo.IsCompleted = input.IsCompleted;

            await _repository.UpdateAsync(toDo);
            return _mapper.Map<ToDoViewModel>(toDo);
        }

        public async Task<ToDoViewModel> Delete(Guid id)
        {
            ToDo? toDo = await _repository.GetByIdAsync(id);

            if (toDo == null) return null;

            await _repository.DeleteAsync(toDo);
            return _mapper.Map<ToDoViewModel>(toDo);
        }
    }
}
