using iCreate.Helpers;
using Microsoft.AspNetCore.SignalR;

namespace iCreate.Hubs
{
    public class CodeHub : Hub
    {
        private readonly UserCodes _userCodes;
        public CodeHub(UserCodes userCodes)
        {
            _userCodes = userCodes;
        }
        public async Task AddCode()
        {
            int code = 0;
            foreach(int c in _userCodes.randomCodes)
            {
                if (!_userCodes.codesList.Contains(c))
                {
                    code = c;
                    break;
                }
            }
            _userCodes.codesList.Add(code);
            await Clients.Caller.SendAsync("ReceiveCode", code);
        }
    }
}
