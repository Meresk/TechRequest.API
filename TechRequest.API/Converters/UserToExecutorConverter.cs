using TechRequest.API.Dtos.User;
using TechRequest.API.Interfaces;
using TechRequest.API.Models;

namespace TechRequest.API.Converters
{
    public class UserToExecutorConverter : IConverter<User, ExecutorDto>
    {
        public ExecutorDto Convert(User user) => new()
        {
            UserId = user.UserId,
            Login = user.Login,
            Name = user.Name,
            Surname = user.Surname,
            Patronymic = user.Patronymic,
        };
    }
}
