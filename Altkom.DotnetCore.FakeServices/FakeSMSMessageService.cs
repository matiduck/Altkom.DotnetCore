using Altkom.DotnetCore.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.DotnetCore.FakeServices
{
    public class FakeSMSMessageService : IMessageService
    {
        public void Send(string message)
        {
            throw new NotImplementedException();
        }
    }
}
