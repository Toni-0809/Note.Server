using Note_3.DTOs;
using Note_3.Entities;﻿
using Note_3.Utilities;

namespace Note_3.Mapper
{
    public static class SecurityMapper
    {
        public static UserSecurity ToEntity(this SecurityRequest request)
        {
            return new UserSecurity()
            {
                Login = request.Login,
                Password = Encoder.ComputeSHA256Hash(request.Password),
            };
        }

        public static SecurityResponse ToResponse(this User user)
        {
            return new SecurityResponse(
                user.Id
            );
        }
    }
}