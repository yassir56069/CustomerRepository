using Blazored.LocalStorage;

namespace CustomerRepo.Services
{
    public class AuthService(ILocalStorageService localStorage)
    {
        private readonly ILocalStorageService _localStorage = localStorage;

        public async Task<bool> LoginAsync(string username, string password)
        {
            // Replace this with your API call
            var token = await FakeAuthenticateAsync(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                await _localStorage.SetItemAsync("authToken", token);
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("authToken");
        }

        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>("authToken");
        }

        private static Task<string> FakeAuthenticateAsync(string username, string password)
        {
            // Simulated API call returning a token
            return Task.FromResult(username == "admin" && password == "password" ? "fake-jwt-token" : null);
        }
    }
}