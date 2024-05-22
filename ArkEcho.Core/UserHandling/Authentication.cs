using System;
using System.Threading.Tasks;

namespace ArkEcho.Core
{
    public class Authentication
    {
        private Rest rest = null;
        private ILocalStorage localStorage = null;

        public User AuthenticatedUser { get; private set; }

        public Authentication(ILocalStorage localStorage, Rest rest)
        {
            this.localStorage = localStorage;
            this.rest = rest;
        }

        public async Task<bool> CheckUserAuthenticated()
        {
            try
            {
                Guid accessToken = await localStorage.GetGuidAsync(Resources.SESSIONTOKENSETTING);
                if (accessToken == Guid.Empty)
                    return false;

                if (!await rest.CheckSession(accessToken))
                {
                    await localStorage.RemoveItemAsync(Resources.SESSIONTOKENSETTING);
                    return false;
                }

                AuthenticatedUser = await rest.GetUser(accessToken);
                if (AuthenticatedUser == null)
                {
                    await localStorage.RemoveItemAsync(Resources.SESSIONTOKENSETTING);
                    return false;
                }

                await localStorage.SetGuidAsync(Resources.SESSIONTOKENSETTING, AuthenticatedUser.SessionToken);
                rest.ApiToken = await rest.GetApiToken(AuthenticatedUser.SessionToken);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public async Task<bool> AuthenticateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            AuthenticatedUser = await rest.AuthenticateUser(username, Encryption.EncryptSHA256(password));

            if (AuthenticatedUser == null)
                return false;

            await localStorage.SetGuidAsync(Resources.SESSIONTOKENSETTING, AuthenticatedUser.SessionToken);
            rest.ApiToken = await rest.GetApiToken(AuthenticatedUser.SessionToken);
            return true;
        }

        public async Task<bool> LogoutUser()
        {
            try
            {
                Guid accessToken = await localStorage.GetGuidAsync(Resources.SESSIONTOKENSETTING);
                await localStorage.RemoveItemAsync(Resources.SESSIONTOKENSETTING);
                await rest.LogoutSession(accessToken);
                AuthenticatedUser = null;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}