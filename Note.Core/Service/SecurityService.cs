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

        public async Task Login(SecurityRequest securityRequest)
        {
            throw new NotImplementedException();
        }

        public async Task Register(SecurityRequest securityRequest)
        {
            throw new NotImplementedException();
        }
    }
}