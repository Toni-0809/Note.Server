using Note_3.DTOs;

namespace Note_3.Mapper
{
    public static class UserMapper
    {
        public static Note_3.Entities.User ToEntity(this AddUserDTO game)
        {
            return new Entities.User()
            {
                Name = game.Name,
            };

        }

        public static Entities.User ToEntity(this UpdateUserDTO game, int id)
        {
            return new Entities.User()
            {
                Name = game.Name,
            };
        }

        public static UserDTO ToUserDTO(this Entities.User game)
        {
            return new UserDTO(

              game.Id,
              game.Name
            );
        }
    }
}
