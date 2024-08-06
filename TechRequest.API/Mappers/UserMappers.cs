using TechRequest.API.Dtos.User;
using TechRequest.API.Models;

namespace TechRequest.API.Mappers
{
    public static class UserMappers
    {
        /*
         * Метод расширения для преобразования из DTO user в Model user
         */
        public static User ToUserFromCreateDto(this CreateUserRequestDto UserDto)
        {
            return new User
            {
                Login = UserDto.Login,
                Password = UserDto.Password,
            };
        }
    }
}
