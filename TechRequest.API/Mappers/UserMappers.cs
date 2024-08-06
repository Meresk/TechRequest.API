using TechRequest.API.Dtos.User;
using TechRequest.API.Models;

namespace TechRequest.API.Mappers
{
    public static class UserMappers
    {
        /*
         * Метод расширения для преобразования из DTO user в Model user
         */
        public static User ToUserFromCreateDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Login = userDto.Login,
                Password = userDto.Password,
            };
        }

        public static ApplicantDto ToApplicantDto(this User user) => new ApplicantDto
        {
            UserId = user.UserId,
            Login = user.Login,
            Name = user.Name,
            Surname = user.Surname,
            Patronymic = user.Patronymic,
        };

        public static ExecutorDto ToExecutorDto(this User user) => new ExecutorDto
        {
            UserId = user.UserId,
            Login = user.Login,
            Name = user.Name,
            Surname = user.Surname,
            Patronymic = user.Patronymic,
        };
    }
}
