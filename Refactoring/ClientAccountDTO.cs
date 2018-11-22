using System;

namespace Refactoring
{
    public class ClientAccountDTO
    {
        private int clientAccountId;

        public int ClientAccountId
        {
            get {
                return clientAccountId;
            }
            set {
                clientAccountId = value;
            }
        }
    }
}
