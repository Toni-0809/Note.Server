using Note_3.DTOs;

namespace Note.Core
{
    public class SecurityService
    {
        private SecurityRemoteDataSource securityRemoteDataSource;

        public SecurityService(SecurityRemoteDataSource securityRemoteDataSource)
        {
            this.securityRemoteDataSource = securityRemoteDataSource;
        }

        public async Task<SecurityResponse> Login(SecurityRequest securityRequest)
        {
            return await securityRemoteDataSource.Login(securityRequest);
        }

        public async Task Register(SecurityRequest securityRequest)
        {
            await securityRemoteDataSource.Register(securityRequest);
        }
    }
}